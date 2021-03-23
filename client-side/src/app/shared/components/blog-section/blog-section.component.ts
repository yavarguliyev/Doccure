import { Component, OnInit } from '@angular/core';
import { Blog, BlogB } from '../../models/blog';
import { DoctorD } from '../../models/doctor';

@Component({
  selector: 'app-blog-section',
  templateUrl: './blog-section.component.html'
})
export class BlogSectionComponent implements OnInit {

  public blogs: Blog[] = [];

  constructor() { }

  ngOnInit(): void {
    const d1 = new DoctorD(1, 'Ruby Perrin', 'ruby-perrin', 'assets/img/doctors/doctor-thumb-01.jpg');
    const b1 = new BlogB(1, 'Doccure – Making your clinic painless visit?', 'doccure-–-making-your-clinic-painless-visit', 'assets/img/blog/blog-01.jpg', d1);

    const d2 = new DoctorD(2, 'Darren Elder', 'darren-elder', 'assets/img/doctors/doctor-thumb-02.jpg');
    const b2 = new BlogB(2, 'What are the benefits of Online Doctor Booking?', 'what-are-the-benefits-of-online-doctor-booking', 'assets/img/blog/blog-02.jpg', d2);

    const d3 = new DoctorD(3, 'Deborah Angel', 'deborah-angel', 'assets/img/doctors/doctor-thumb-03.jpg');
    const b3 = new BlogB(3, 'Benefits of consulting with an Online Doctor', 'benefits-of-consulting-with-an-online-doctor', 'assets/img/blog/blog-03.jpg', d3);

    const d4 = new DoctorD(4, 'Sofia Brient', 'sofia-brient', 'assets/img/doctors/doctor-thumb-04.jpg');
    const b4 = new BlogB(4, '5 Great reasons to use an Online Doctor', '5-great-reasons-to-use-an-online-doctor', 'assets/img/blog/blog-04.jpg', d4);

    this.blogs.push(b1);
    this.blogs.push(b2);
    this.blogs.push(b3);
    this.blogs.push(b4);
  }

}
