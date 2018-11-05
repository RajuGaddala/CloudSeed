import { Headers } from '@angular/http';

export const contentHeaders = new Headers();
contentHeaders.append('Accept', '*/*');
//contentHeaders.append('Content-Type', 'application/json');
contentHeaders.append('Content-Type', 'application/x-www-form-urlencoded');
contentHeaders.append('Access-Control-Allow-Origin', '*');
contentHeaders.append('Access-Control-Allow-Methods', 'POST, GET, PUT, OPTIONS, DELETE');
//contentHeaders.append('grant_type', 'password');
//contentHeaders.append('credentials', 'true');
//contentHeaders.append('scope', 'write');
