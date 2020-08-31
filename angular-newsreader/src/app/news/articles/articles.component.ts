import { Component, OnInit } from '@angular/core';
import { Article } from 'src/app/shared/article.model';
import { ArticleService } from 'src/app/shared/article.service';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css']
})
export class ArticlesComponent implements OnInit {

  constructor(private service:ArticleService) { }

  ngOnInit(): void {
  }

  loadArticles(event: any){
    this.service.getArticles().subscribe();
    console.log("loadArticles ok");
    event.target.disabled = true;
  };
  
}
