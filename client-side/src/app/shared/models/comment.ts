import { User } from './user';

export interface Comment {
  id: number;
  blogId: number;
  text: string;
  isReply: boolean;
  userDTO: User;
  addedDate: Date;
  commentReplyDTOs: CommentReply[];
}

export class CommentFormValues {
  text: string;
  slug: string;
  email: string;

  constructor(text: string, slug: string, email: string) {
    this.text = text;
    this.slug = slug;
    this.email = email;
  }
}

export interface CommentReply {
  text: string;
  commentId: number;
  addedDate: Date;
  userDTO: User;
}

export class CommentReplyFormValues {
  text: string;
  slug: string;
  email: string;
  commentId: number;

  constructor(text: string, slug: string, email: string, commentId: number) {
    this.text = text;
    this.slug = slug;
    this.email = email;
    this.commentId = commentId;
  }
}
