using Convex.Net.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Convex.Net {
    public class Startup {
        #region MEMBERS

        public IConfiguration Configuration { get; }
        public IrcService IrcClient { get; private set; }
        private Handshake Handshake { get; set; }

        #endregion

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
            services.Add(new ServiceDescriptor(typeof(Handshake), Handshake = new Handshake("temporarypass")));
            services.Add(new ServiceDescriptor(typeof(IrcService), IrcClient = new IrcService("irc.foonetic.net", 6667)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
    }
}
