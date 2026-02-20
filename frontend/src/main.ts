import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';
import { provideRouter } from '@angular/router';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: true,
  template: `
    <main class="min-h-screen bg-slate-950 text-slate-100 flex items-center justify-center p-8">
      <section class="max-w-3xl w-full rounded-2xl border border-slate-800 bg-slate-900/60 p-10 shadow-2xl">
        <h1 class="text-4xl font-bold mb-4">DevTrackAI</h1>
        <p class="text-slate-300 mb-6">Production-ready Angular frontend with dark mode + Tailwind.</p>
        <div class="grid sm:grid-cols-3 gap-4">
          <div class="p-4 rounded-lg bg-slate-800 border border-slate-700">
            <p class="font-semibold">API</p>
            <p class="text-sm text-slate-400">ASP.NET Core 8 + Oracle</p>
          </div>
          <div class="p-4 rounded-lg bg-slate-800 border border-slate-700">
            <p class="font-semibold">Auth</p>
            <p class="text-sm text-slate-400">JWT bearer secured endpoints</p>
          </div>
          <div class="p-4 rounded-lg bg-slate-800 border border-slate-700">
            <p class="font-semibold">Infra</p>
            <p class="text-sm text-slate-400">Docker compose multi-container</p>
          </div>
        </div>
      </section>
    </main>
  `
})
class AppComponent {}

bootstrapApplication(AppComponent, {
  providers: [provideHttpClient(), provideRouter([])]
}).catch((error: unknown) => console.error(error));
