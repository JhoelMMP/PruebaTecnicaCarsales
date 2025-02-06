export interface EpisodioResponse {
  id:         number;
  name:       string;
  air_date:    null;
  episode:    string;
  characters: string[];
  url:        string;
  created:    string;
}

export interface Episodios {
  data:    EpisodioResponse[]
  loading: boolean;
}
