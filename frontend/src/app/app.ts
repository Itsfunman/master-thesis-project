import { Component, signal } from '@angular/core';


@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class AppComponent {
  greeting = signal<string>('');
  error = signal<string>('');

  async sayHello() {
    this.error.set('');
    try {
      const res = await fetch('/api/hello?name=Angular');
      if (!res.ok) throw new Error(`HTTP ${res.status}`);
      const data = await res.json();
      console.log('API data:', data);
      this.greeting.set(data?.message ?? JSON.stringify(data));
    } catch (e: any) {
      this.error.set(e?.message ?? String(e));
    }
  }
}
