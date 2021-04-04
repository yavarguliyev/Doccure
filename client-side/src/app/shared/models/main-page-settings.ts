import { SocialMedia } from './social-media-settings';

export interface MainPageSettings {
  clinicAndSpecialitiesTitle: string;
  clinicAndSpecialitiesSubTitle: string;
  availableTitle: string;
  availableSubTitle: string;
  blogsAndNewsTitle: string;
  blogsAndNewsSubTitle: string;
  popularTitle: string;
  popularSubTitle: string;
  popularText: string;
  address: string;
  contactNumber: string;
  email: string;
  footerDesc: string;
  footerSite: string;
  socialMediaDTOs: SocialMedia[];
}
