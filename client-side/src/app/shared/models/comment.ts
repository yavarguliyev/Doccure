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
  userId: number;

  constructor(text: string, slug: string, userId: number) {
    this.text = text;
    this.slug = slug;
    this.userId = userId;
  }
}

export interface CommentReply {
  text: string;
  commentId: number;
  addedDate: Date;
  userDTO: User;
}
