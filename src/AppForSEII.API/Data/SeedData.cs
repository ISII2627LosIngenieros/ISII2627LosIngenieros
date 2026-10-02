namespace AppForSEII.API.Data {
    public class SeedData {
        public static void Initialize(ApplicationDbContext dbContext, IServiceProvider serviceProvider, ILogger logger) {
            List<string> rolesNames = new List<string> { "Administrator", "Employee", "Customer" };

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            try {
                SeedRoles(roleManager, rolesNames);
            }
            catch (Exception ex) {
                logger.LogError(ex, "An error occurred seeding the roles in the Database.");
            }

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            try {
                SeedUsers(userManager, rolesNames);
            }
            catch (Exception ex) {
                logger.LogError(ex, "An error occurred seeding the Users in the Database.");
            }

            try {
                //it initializes the database with genres and movies
                SeedGenresAndMovies(dbContext);
            }
            catch (Exception ex) {
                logger.LogError(ex, "An error occurred seeding the Movies and Genres in the Database.");
            }

            try {
                var user = dbContext.Users.OfType<ApplicationUser>().FirstOrDefault(u => u.UserName == "elena@uclm.es");

                //it initializes the database with a Rental
                SeedRental(dbContext, user);
            }
            catch (Exception ex) {
                logger.LogError(ex, "An error occurred seeding a Rental in the Database.");
            }
        }

        private static void SeedRental(ApplicationDbContext dbContext, ApplicationUser? user)
        {
            throw new NotImplementedException();
        }

        private static void SeedGenresAndMovies(ApplicationDbContext dbContext)
        {
            throw new NotImplementedException();
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager, List<string> roles) {

            foreach (string roleName in roles) {
                //it checks such role does not exist in the database 
                if (!roleManager.RoleExistsAsync(roleName).Result) {
                    IdentityRole role = new IdentityRole();
                    role.Name = roleName;
                    role.NormalizedName = roleName;
                    IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                }
            }

        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager, List<string> roles) {
            //first, it checks the user does not already exist in the DB
            if (userManager.FindByNameAsync("elena@uclm.es").Result == null) {
                ApplicationUser user = new ApplicationUser("1", "Elena", "Navarro Martínez", "elena@uclm.es", 30, "12345678A", "F");
                user.EmailConfirmed = true;

                var result = userManager.CreateAsync(user, "Password1234%");
                result.Wait();

                if (result.IsCompletedSuccessfully) {
                    //administrator role
                    userManager.AddToRoleAsync(user, roles[0]).Wait();
                }
            }

            if (userManager.FindByNameAsync("gregorio@uclm.es").Result == null) {
                ApplicationUser user = new ApplicationUser("2", "Gregorio", "Diaz Descalzo", "gregorio@uclm.es", 40, "87654321B", "M");
                user.EmailConfirmed = true;

                var result = userManager.CreateAsync(user, "APassword1234%");
                result.Wait();

                if (result.IsCompletedSuccessfully) {
                    //employee role
                    userManager.AddToRoleAsync(user, roles[1]).Wait();
                }
            }

            if (userManager.FindByNameAsync("peter@uclm.es").Result == null) {
                //A customer class has been defined because it has different attributes (purchase, rental, etc.)
                ApplicationUser user = new ApplicationUser("3", "Peter", "Jackson", "peter@uclm.es", 35, "11223344C", "M");
                user.EmailConfirmed = true;

                var result = userManager.CreateAsync(user, "OtherPass12$");

                result.Wait();

                if (result.IsCompletedSuccessfully) {
                    //customer role
                    userManager.AddToRoleAsync(user, roles[2]).Wait();

                }
            }

        }

        public static void SeedTiposYMateriales(ApplicationDbContext dbcontext) 
        {
            string[] tiposNombres = { "Raquetas", "Balones", "Protecciones", "Redes" };
            List<TipoMaterial> tiposMaterial = new List<TipoMaterial>();

            foreach (string nombreTipo in tiposNombres) {
                var tipo = dbcontext.TiposMaterial.FirstOrDefault(t => t.NameTipoMaterial == nombreTipo);
                if (tipo == null) {
                    var nuevoTipo = new TipoMaterial { IdTipoMaterial = nombreTipo.Substring(0, 3).ToUpper(), NameTipoMaterial = nombreTipo };
                    tiposMaterial.Add(nuevoTipo);
                    dbcontext.TiposMaterial.Add(nuevoTipo);
                }
                else {
                    tiposMaterial.Add(tipo);
                }
            }

            dbcontext.SaveChanges(); 

            if (dbcontext.Materiales.FirstOrDefault(m => m.NombreMaterial == "Raqueta de Tenis Profesional") == null) {
                var material1 = new Material {
                    NombreMaterial = "Raqueta de Tenis Profesional",
                    Cantidad = 15,
                    PrecioMaterial = 5.50m,
                    TipoMaterial = tiposMaterial[0]
                };
                dbcontext.Materiales.Add(material1);
            }

            if (dbcontext.Materiales.FirstOrDefault(m => m.NombreMaterial == "Balón de Baloncesto Talla 7") == null) {
                var material2 = new Material {
                    NombreMaterial = "Balón de Baloncesto Talla 7",
                    Cantidad = 20,
                    PrecioMaterial = 3.00m,
                    TipoMaterial = tiposMaterial[1]
                };
                dbcontext.Materiales.Add(material2);
            }

            dbcontext.SaveChanges();
        }

       public static void SeedAlquiler(ApplicationDbContext dbcontext, ApplicationUser user) 
        {
            if (dbcontext.Alquiler.FirstOrDefault() == null) {
                var material = dbcontext.Materiales.First();
                
                var alquiler = new Alquiler {
                    Cliente = user,
                    FechaAlquiler = DateTime.Now,
                    MetodoPago = "Tarjeta", //MetodoPago.Tarjeta
                    PrecioTotal = material.PrecioMaterial * 2, 
                    MaterialesAlquilados = new List<MaterialAlquilado>()
                };

                var materialAlquilado = new MaterialAlquilado {
                    Material = material,
                    IdMaterial = material.IdMaterial,
                    Alquiler = alquiler,
                    Cantidad = 2,
                    PrecioMaterialAlquilado = material.PrecioMaterial * 2,
                    Descripcion = "Alquiler de prueba para el fin de semana"
                };

                alquiler.MaterialesAlquilados.Add(materialAlquilado);
                dbcontext.Alquiler.Add(alquiler);
                
                dbcontext.SaveChanges();
            }
        }
    }
}