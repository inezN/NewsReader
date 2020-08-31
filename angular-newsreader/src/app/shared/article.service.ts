import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
  })

export class ArticleService {
    constructor(private http:HttpClient) { }
    
 getArticles(){
    return this.http.get("https://localhost:44382/api/LoadNews");
 }

}
    