using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ants_prog
{
	class Prog
	{
		static Random random = new Random();
		static List<Heap> h = CreateHeaps(); 
		static List<Queen> greenQ = GreenQ();
		static List<Worker> greenWo = GreenWo();
		static List<Warrior> greenWa = GreenWa();
		static List<Queen> redQ = RedQ();
		static List<Worker> redWo = RedWo();
		static List<Warrior> redWa = RedWa();
		static int greenres = 0;
		static int redres = 0;
		static int Time = 1;
		static int qg = greenQ[0].Gcycle;
		static int qr = redQ[0].Gcycle;
		static int q = 0;
		static int qq = 0;
		static Colony greencolony = Colonies()[0]; // колония 1
		static Colony redcolony = Colonies()[1];
		static List<Colony> newcolonies = NewColonies();
		class Ant
		{
			public string Ncolony { get; set; }
			public string name { get; set; }
			public int health { get; set; }
			public int protection { get; set; }
			public Ant(string Ncolony, string name, int health, int protection)
			{
				this.Ncolony = Ncolony;
				this.name = name;
				this.health = health;
				this.protection = protection;
			}
		}
		class Worker : Ant
		{
			public int twig;
			public int stone;
			public int dewdrop;
			public int leaf;
			public Worker(string Ncolony, string name, int health, int protection, int twig, int stone, int dewdrop, int leaf) : base(Ncolony, name, health, protection)
			{
				this.twig = twig;
				this.stone = stone;
				this.dewdrop = dewdrop;
				this.leaf = leaf;
			}
		}
		class Warrior : Ant
		{
			public int damage;
			public int cdamage;
			public int bite;
			public Warrior(string Ncolony, string name, int health, int protection, int damage, int cdamage, int bite) : base(Ncolony, name, health, protection)
			{
				this.damage = damage;
				this.cdamage = cdamage;
				this.bite = bite;
			}
		}
		
		class Queen : Ant
		{
			public int damage;
			public int Gcycle;
			public int Qcreating;
			public Queen(string Ncolony, string name, int health, int protection, int damage, int Gcycle, int Qcreating) : base(Ncolony, name, health, protection)
			{
				this.damage = damage;
				this.Gcycle = Gcycle;
				this.Qcreating = Qcreating;
			}
		}
		public class Colony
		{
			public string name;
			public int population;
			public int popwarrior; // популяция войнов
			public int popworker; // популяция сторителей
			public int popspecial; // популяция специальных муравьев
			public int sklad; // склад
			public string status; // статус королевы
			public Colony(string name, int population, int popwarrior, int popworker, int popspecial, int sklad, string status)
			{
				this.name = name;
				this.population = population;
				this.popwarrior = popwarrior;
				this.popworker = popworker;
				this.popspecial = popspecial;
				this.sklad = sklad;
				this.status = status;
			}
		}
		public static List<Colony> Colonies() // создаю коллекцию колоний
		{
			List<Colony> colonies = new List<Colony>()
			{
				new Colony("Зеленые",(GreenWa().Count + GreenWo().Count + 1), GreenWa().Count, GreenWo().Count, 1, greenres, "Нефертити - Жива"),
				new Colony("Рыжие",(RedWa().Count + RedWo().Count + 1), RedWa().Count, RedWo().Count, 1, redres, "Амалия - Жива"),
			};
			return colonies;
		}
		public static List<Colony> NewColonies() // создаю коллекцию колоний
		{
			List<Colony> newcolonies = new List<Colony>()
			{
			};
			return newcolonies;
		}
		static List<Queen> GreenQ()
		{
			List<Queen> greenQ = new List<Queen>()
			{
				new Queen("зеленые", "Нефертити", 17,9,19,3, random.Next(3,5))
			};
			return greenQ;
		}
		static List<Worker> GreenWo()
		{
			List<Worker> greenWo = new List<Worker>()
			{
			};
			return greenWo;
		}
		static List<Warrior> GreenWa()
		{
			List<Warrior> greenWa = new List<Warrior>()
			{
				new Warrior("зеленые", "ОСОБЕННОЕ - Медведка", 16,8,5,2,2)
			};
			return greenWa;
		}
		
		static List<Queen> RedQ()
		{
			List<Queen> redQ = new List<Queen>()
			{
				new Queen("рыжие", "Амалия", 20,7,22,5, random.Next(2,3))
			};
			return redQ;
		}
		static List<Worker> RedWo()
		{
			List<Worker> redWo = new List<Worker>()
			{
				new Worker("рыжие", "ОСОБЕННОЕ - Сверчок", 29, 6, 0, 0, 3, 0)
			};
			return redWo;
		}
		static List<Warrior> RedWa()
		{

			List<Warrior> redWa = new List<Warrior>()
			{
			};
			return redWa;
		}


		public class Heap
		{
			public int twig;
			public int stone;
			public int dewdrop;
			public int leaf;
			public Heap(int twig, int stone, int dewdrop, int leaf)
			{
				this.twig = twig;
				this.stone = stone;
				this.dewdrop = dewdrop;
				this.leaf = leaf;
			}
		}
		static List<Heap> CreateHeaps()
		{
			var h = new List<Heap>
			{
				new Heap(36, 0, 0, 0),
				new Heap(11, 42, 0, 0),
				new Heap(25, 20, 16, 0),
				new Heap(28, 22, 0, 22),
				new Heap(42, 0, 32, 0)
			};
			return h;
		}
		static void Main(string[] args)
		{
			for (int i = 0; i < 8; i++)
			{
				int tip = random.Next(1, 4);
				switch (tip)
				{
					case 1:
						redWa.Add(new Warrior("рыжие", "старший", 2, 1, 2, 1, 1));
						break;
					case 2:
						redWa.Add(new Warrior("рыжие", "элитный", 8, 4, 3, 2, 2));
						break;
					case 3:
						redWa.Add(new Warrior("рыжие", "легендарный крепкий", 10, 6, 4, 3, 1));
						break;
				}
			}
			for (int i = 0; i < 12; i++)
			{
				int tip = random.Next(1, 4);
				switch (tip)
				{
					case 1:
						redWo.Add(new Worker("рыжие", "элитный", 8, 4, 0, 0, 2, 0));
						break;
					case 2:
						redWo.Add(new Worker("рыжие", "легендарный", 10, 6, 0, 0, 1, 2));
						break;
					case 3:
						redWo.Add(new Worker("рыжие", "продвинутый карманник", 6, 2, 0, 0, 0, 2));
						break;
				}
			}
			for (int i = 0; i < 11; i++)
			{
				int tip = random.Next(1, 4);
				switch (tip)
				{
					case 1:
						greenWo.Add(new Worker("зеленые", "элитный", 8, 4, 2, 0, 0, 0));
						break;
					case 2:
						greenWo.Add(new Worker("зеленые", "легендарный", 10, 6, 0, 0, 2, 1));
						break;
					case 3:
						greenWo.Add(new Worker("зеленые", "продвинутый неповторимый", 6, 2, 0, 0, 2, 1));
						break;
				}
			}
			for (int i = 0; i < 6; i++)
			{
				int tip = random.Next(1, 4);
				switch (tip)
				{
					case 1:
						greenWa.Add(new Warrior("зеленые", "элитный", 8, 4, 3, 2, 2));
						break;
					case 2:
						greenWa.Add(new Warrior("зеленые", "продвинутый", 6, 2, 3, 2, 1));
						break;
					case 3:
						greenWa.Add(new Warrior("зеленые", "продвинутый берсерк", 6, 2, 3, 2, 1));
						break;
				}
			}
			bool is_exit = false;
			while (!is_exit)
			{
				Console.Clear();

				Console.Write($"\nДень {Time}\nЧто вы хотите сделать?\n\n1 - Показать информацию о колониях\n2 - Начать новый день\nВвод: ");
				bool is_correct = int.TryParse(Console.ReadLine(), out int watcher_choose);
				while (!is_correct | watcher_choose < 1 | watcher_choose > 2) { Console.Write("Again: "); is_correct = int.TryParse(Console.ReadLine(), out watcher_choose); }

				switch (watcher_choose)
				{
					case 1:
						Console.Clear();
						int i = Time;
						Console.WriteLine($"\nДо засухи {14 - i} дней");
						int moleccount = 0;
						int ccount = 0;
						int greencount = 0;
						int redcount = 0;
						for (int cc = 0; cc < greenWa.Count(); cc++)
						{
							if (greenWa[cc].name== "ОСОБЕННОЕ - Медведка")
							{
								moleccount += 1;
							}
							else
							{
								greencount += 1;
							}
						}
						for (int cc = 0; cc < redWo.Count(); cc++)
						{
							if (redWo[cc].name == "ОСОБЕННОЕ - Сверчок")
							{
								ccount += 1;
							}
							else
							{
								redcount += 1;
							}
						}
						Console.WriteLine($"Колония {greencolony.name}, Популяция - {greencount + greenWo.Count + moleccount + 1}, Популяция войнов - {greencount}, Популяция рабочих - {greenWo.Count}, Популяция специальных - {moleccount}, Королева - {greencolony.status}, Ресурсов - {greenres} ");
						Console.WriteLine($"Рабочие:");
						for (int k = 0; k < greenWo.Count; k++)
						{
							Console.WriteLine($"тип-{greenWo[k].name}, здоровье-{greenWo[k].health}, защита-{greenWo[k].protection}");
						}
						Console.WriteLine($"Воины:");
						for (int n = 0; n < greenWa.Count; n++)
						{
							if (greenWa[n].name != "ОСОБЕННОЕ - Медведка")
							{
								Console.WriteLine($"тип-{greenWa[n].name}, здоровье-{greenWa[n].health}, защита-{greenWa[n].protection}");
							}
						}
						Console.WriteLine($"Особые насекомые:");
						for (int n = 0; n < greenWa.Count; n++)
						{
							if (greenWa[n].name == "ОСОБЕННОЕ - Медведка")
							{
								Console.WriteLine($"тип-{greenWa[n].name}, здоровье-{greenWa[n].health}, защита-{greenWa[n].protection}");
							}
						}
						Console.WriteLine($"Колония {redcolony.name}, Популяция - {redWa.Count + redcount + ccount + 1}, Популяция войнов - {redWa.Count}, Популяция рабочих - {redWo.Count}, Популяция специальных - {ccount}, Королева - {redcolony.status}, Ресурсов - {redres} ");
						Console.WriteLine($"Рабочие:");
						for (int j = 0; j < redWo.Count; j++)
						{
							if (redWo[j].name!= "ОСОБЕННОЕ - Сверчок")
							{
								Console.WriteLine($"тип- {redWo[j].name} , здоровье- {redWo[j].health} , защита-{redWo[j].protection}");
							}
						}
						Console.WriteLine($"Воины:");
						for (int h = 0; h < redWa.Count; h++)
						{
							Console.WriteLine($"тип- {redWa[h].name} , здоровье- {redWa[h].health} , защита-{redWa[h].protection}");
						}
						Console.WriteLine($"Особые насекомые:");
						for (int j = 0; j < redWo.Count; j++)
						{
							if (redWo[j].name == "ОСОБЕННОЕ - Сверчок")
							{
								Console.WriteLine($"тип- {redWo[j].name} , здоровье- {redWo[j].health} , защита-{redWo[j].protection}");
							}
						}
						if (newcolonies.Count()>0)
						{
							for (int nk = 0; nk < newcolonies.Count(); nk++)
							{
								Console.WriteLine($"Колония { newcolonies[nk].name}, Популяция - {1}, Популяция войнов - {0}, Популяция рабочих - {0}, Популяция специальных - {0}, Королева - { newcolonies[nk].status}, ");
							}
						}
						Console.ReadKey();
						
						break;
					case 2:
						Console.Clear();
						if (Time == qg)
						{
							
							for (int a = 0; a < 3; a++)
							{
								int nnew = random.Next(1, 9);
								switch (nnew)
								{
									case 1:
										q += 1;
										int coloniya = random.Next(1,3); // проверка создаст ли новая королева новую колонию
										if (coloniya == 1)
										{  
											redQ.Add(new Queen("зеленые", "Нефертити", 20, 7, 22, 0, 0));
											
											newcolonies.Add(new Colony("новые рыжие", 0, 0, 0, 0, 0, "Новая Нефертити - жива"));
											Console.WriteLine($"Вылупилась королева! И решила создать свою колонию!");
										}
										else
										{
											
											Console.WriteLine("Вылупилась королева, но не стала создавать колонию и ушла");
										}
										break;
									case 2:
										greenWa.Add(new Warrior("зеленые", "элитный", 8, 4, 3, 2, 2));
										break;
									case 3:
										greenWa.Add(new Warrior("зеленые", "продвинутый", 6, 2, 3, 2, 1));
										break;
									case 4:
										greenWa.Add(new Warrior("зеленые", "продвинутый берсерк", 6, 2, 3, 2, 1));
										break;
									case 5:
										greenWo.Add(new Worker("зеленые", "элитный", 8, 4, 2, 0, 0, 0));
										break;
									case 6:
										greenWo.Add(new Worker("зеленые", "легендарный", 10, 6, 0, 0, 2, 1));
										break;
									case 7:
										greenWo.Add(new Worker("зеленые", "продвинутый неповторимый", 6, 2, 0, 0, 2, 1));
										break;
									case 8:
										greenWa.Add(new Warrior("зеленые", "Медведка", 16, 8, 5, 2, 2));
										break;
								}
								qg = qg + greenQ[0].Gcycle;
								
								Console.WriteLine("Размножение началось!!!");
								Console.WriteLine($"I Королева Нефертити отложила 3 личинки, они вылупятся на 3 день от дня закладки\n");
							}


						}


						if (Time == qr)
						{
							for (int a = 0; a < 2; a++)
							{
								int nnew = random.Next(1, 9);
								switch (nnew)
								{
									case 1:
										qq += 1;
										int coloniya = 1; // проверка создаст ли новая королева новую колонию
										if (coloniya == 1)
										{
											redQ.Add(new Queen("рыжие", "Амалия", 20, 7, 22, 0, 0));
											
											newcolonies.Add(new Colony("новые рыжие", 0, 0, 0, 0, 0, "Новая Амалия - жива"));
											Console.WriteLine($"Вылупилась королева! И решила создать свою колонию!");
										}
										else
										{
											
											Console.WriteLine("Вылупилась королева, но не стала создавать колонию и ушла");
										}
										break;
									case 2:
										redWa.Add(new Warrior("рыжие", "старший", 2, 1, 2, 1, 1));
										break;
									case 3:
										redWa.Add(new Warrior("рыжие", "элитный", 8, 4, 3, 2, 2));
										break;
									case 4:
										redWa.Add(new Warrior("рыжие", "легендарный крепкий", 10, 6, 4, 3, 1));
										break;
									case 5:
										redWo.Add(new Worker("рыжие", "элитный", 8, 4, 0, 0, 2, 0));
										break;
									case 6:
										redWo.Add(new Worker("рыжие", "легендарный", 10, 6, 0, 0, 1, 2));
										break;
									case 7:
										redWo.Add(new Worker("рыжие", "продвинутый карманник", 6, 2, 0, 0, 0, 2));
										break;
									case 8:
										redWo.Add(new Worker("рыжие", "Сверчок", 29, 6, 0, 0, 3, 0));
										break;
								}
								qr = qr + redQ[0].Gcycle;
								
								Console.WriteLine("Размножение началось!!!");
								Console.WriteLine($"I Королева Амалия отложила 2 личинки, они вылупятся на 5 день от дня закладки\n");
							}
						}
						
						if (Time == 1)
						{
							
							Console.WriteLine("Размножение началось!!!");
							Console.WriteLine($"I Королева Нефертити отложила 3 личинки, они вылупятся на 3 день от дня закладки\n");
							Console.WriteLine($"I Королева Амалия отложила 2 личинки, они вылупятся на 5 день от дня закладки\n");
						}
						Time++;
						if (Time == 14)
						{
							
							Console.WriteLine("НАСТУПИЛА ЗАСУХА");
							if (greenres > redres)
							{
								Console.WriteLine($"Все муравьи погибли...\n Кроме колонии ЗЕЛЕНЫХ, которая собрала больше всех ресурсов!!!");
							}
							else
							{
								Console.WriteLine($"Все муравьи погибли...\n Кроме колонии РЫЖИХ, которая собрала больше всех ресурсов!!!");
							}
							is_exit = true;
						}
						if (Time < 14)
						{
							Console.WriteLine($"БИТВА НАЧАЛАСЬ\n Первыми атакуют зеленые");
							if (greenWa.Count() > 0)
							{
								for (int y = 0; y < greenWa.Count(); y++)
								{
									int td = random.Next(1, 3);
									switch (td)
									{
										case 1:
											for (int ii = 0; ii < greenWa[y].cdamage; ii++)
											{
												if (redWa.Count == 0)
												{
													break;
												}
												int tt = random.Next(0, redWa.Count);
												int p = redWa[tt].protection;
												int gyron = (greenWa[y].damage - p);
												if ((redWa[tt].name == "легендарный крепкий") & (greenWa[y].name != "ОСОБЕННОЕ - Медведка"))
												{
													gyron = (greenWa[y].damage - p)/ 2;
												}
												if (gyron < 0)
												{
													break;
												}
												redWa[tt].health -= gyron;//зеленый нанес укус
												if (redWa[tt].health < 1)
												{
													Console.WriteLine($"{greenWa[y].name} нанес урон врагам, {redWa[tt].name} потерял все hp и умер");
													redWa.Remove(redWa[tt]);
												}
												else
												{
													Console.WriteLine($"{greenWa[y].name} нанес урон врагам, {redWa[tt].name} потерял {gyron} hp \n завязалась битва");
													if ((greenWa[y].bite == 2) & (greenWa[y].health != 0))
													{
														redWa[tt].health -= gyron; //зеленый нанес второй укус
													}
													int r = greenWa[y].protection;
													int bi = redWa[tt].bite*(redWa[tt].damage-r);
													if ((redWa[tt].damage - r) < 0)
													{
														bi=0;
													}
													greenWa[y].health -= bi;
													
													if (redWa.Count == 0)
													{
														break;
													}
													
													if (greenWa[y].health < 1)
													{
														Console.WriteLine($"По итогам битвы умер муравей {greenWa[y].name} из колонии зеленых, муравей из колонии рыжих остался жив с уроном");
														greenWa.Remove(greenWa[y]);
														break;
													}
													if ((redWa[tt].health < 1) & (greenWa[y].health < 1))
													{
														Console.WriteLine($"По итогам битвы умерли оба муравья");
														greenWa.Remove(greenWa[y]);
														redWa.Remove(redWa[tt]);
														break;
													}
													if ((redWa[tt].health >0) & (greenWa[y].health >0))
													{
														Console.WriteLine($"По итогам битвы живы оба муравья");
													}
													if (redWa[tt].health < 1)
													{
														Console.WriteLine($"По итогам битвы умер муравей {redWa[tt].name} из колонии рыжих, муравей из колонии зеленых остался жив с уроном");
														redWa.Remove(redWa[tt]);
													}

												}
											}

											break;

										case 2:
											if (redWo.Count > 0)
											{
												td = random.Next(0, redWo.Count());
												int flag = 0;
												if ((redWo[td].name == "ОСОБЕННОЕ - Сверчок") & ((greenWa[y].name != "ОСОБЕННОЕ - Медведка")))
												{
													break;
												}
												if ((redWo[td].name == "ОСОБЕННОЕ - Сверчок") & (greenWa[y].name == "ОСОБЕННОЕ - Медведка") && (flag < 1))
												{
													flag = 1;
													break;//тк сверчок не может быть атакован войнами и может пережить 1 любой укус (особенного насекомого)
												}
												int p = redWo[td].protection;
												int gdamage = greenWa[y].damage - p;
												if (gdamage < 0)
												{
													break;
												}
												redWo[td].health -= gdamage;
												if (redWo[td].health == 0)
												{
													Console.WriteLine($"{greenWa[y].name} нанес урон рабочему, {redWo[td].name} потерял все hp и умер");
													redWo.Remove(redWo[td]);
												}
												else
												{
													Console.WriteLine($"{greenWa[y].name} нанес урон рабочему, {redWo[td].name} потерял {gdamage} hp");

												}
											}

											break;

									}
								}

							}



							Console.WriteLine($"БИТВА ПРОДОЛЖАЕТСЯ \n Атакуют рыжие");
							if ((redWa.Count > 0))
							{
								for (int y = 0; y < redWa.Count(); y++)
								{
									if (redWa.Count() == 0)
									{
										break;
									}
									int td = random.Next(1, 3);
									switch (td)
									{
										case 1:
											for (int ii = 0; ii < redWa[y].cdamage; ii++)
											{
												if (greenWa.Count == 0)
												{
													break;
												}
												int tt = random.Next(0, greenWa.Count);
												int p = greenWa[tt].protection;
												int rdamage = redWa[y].damage - p;
												if (rdamage < 0)
												{
													break;
												}
												greenWa[tt].health -= rdamage;
												if (greenWa[tt].health == 0)
												{
													Console.WriteLine($"{redWa[y].name} нанес урон врагам, {greenWa[tt].name} потерял все hp и умер");
													redWa.Remove(greenWa[tt]);
												}
												else
												{
													Console.WriteLine($"{redWa[y].name} нанес урон врагам, {greenWa[tt].name} потерял {rdamage} hp \n завязалась битва");
													int rp = redWa[y].protection;
													int k = greenWa[tt].bite;
													int gyron = (greenWa[tt].damage-rp)*k;
													if (gyron < 0)
													{
														gyron = 0;
													}
													if ((redWa[y].name == "легендарный крепкий") &(greenWa[tt].name != "ОСОБЕННОЕ - Медведка"))
													{
														gyron = gyron / 2;
													}
													redWa[y].health -= gyron;
													int bi = redWa[y].bite - 1;
													int r = greenWa[tt].protection;
													rdamage = bi * (redWa[y].damage - r);
													if (rdamage < 0)
													{
														rdamage = 0;
													}
													greenWa[tt].health -= rdamage;
												}
												if (redWa[y].health < 1)
												{
													Console.WriteLine($"По итогам битвы умер муравей {redWa[y].name} из колонии рыжих, муравей из колонии зеленых остался жив с уроном");
													redWa.Remove(redWa[tt]);
													break;
												}
												if ((redWa[y].health < 1) & (greenWa[tt].health < 1))
												{
													Console.WriteLine($"По итогам битвы умерли оба муравья");
													greenWa.Remove(greenWa[tt]);
													redWa.Remove(redWa[y]);
													break;
												}
												if ((redWa[y].health > 0) & (greenWa[tt].health > 0))
												{
													Console.WriteLine($"По итогам битвы живы оба муравья");
												}
												if (greenWa[tt].health < 1)
												{
													Console.WriteLine($"По итогам битвы умер муравей {greenWa[tt].name} из колонии зеленых, муравей из колонии рыжих остался жив с уроном");
													greenWa.Remove(greenWa[tt]);

												}
											}
											break;
										case 2:
											if (greenWo.Count > 0)
											{
												td = random.Next(0, greenWo.Count());
												if (greenWo[td].name=="продвинутый неповторимый")
												{
													break; //тк он неуязвим для любых атак
												}
												int p = greenWo[td].protection;
												if(redWa[y].damage - p<0)
												{
													p = redWa[y].damage;
												}
												greenWo[td].health = redWa[y].damage - p;
												if (greenWo[td].health == 0)
												{
													Console.WriteLine($"{redWa[y].name} нанес урон рабочему, {greenWo[td].name} потерял все hp и умер");
													redWo.Remove(greenWo[td]);
												}
												else
												{
													Console.WriteLine($"{redWa[y].name} нанес урон рабочему, {greenWo[td].name} потерял {redWa[y].damage-p} hp и защиты");
													
												}
											}
											break;
									}
								}
							}
							
							Console.WriteLine($"\n ИНФОРМАЦИЯ О ПОХОДАХ \n КОЛОНИЯ ЗЕЛЕНЫХ");
							for (int po = 0; po < greenWo.Count; po++) // идёт в поход первая колония
							{
								int nomerkuchi = random.Next(1, 6); // определитель в какую кучу пойдёт муравей
								int flag = 0;
								int n = 0;
								switch (nomerkuchi)
								{
									case 1://идет на кучу 1
										if ((h[0].twig == 0) & (h[0].stone == 0) & (h[0].dewdrop == 0) & (h[0].leaf == 0))
										{
											flag = 1;
											break; //кучу уничтожил жук-носорог
										}
										if (((h[0].twig - greenWo[po].twig) > 0) & (greenWo[po].twig != 0))
										{
											h[0].twig -= greenWo[po].twig;
											greenres += 1;
											n = 1;
										}
										if ((greenWo[po].name == "продвинутый неповторимый") & ((h[0].twig - greenWo[po].twig) > 0)&(n==1))
										{
											h[0].twig -= greenWo[po].twig;
											greenres += 1;
										}
										if ((greenWo[po].name == "продвинутый неповторимый") & ((h[0].twig - greenWo[po].twig) == 0)&(n==0))
										{
											greenres += 2;
										}
											
									break;
									case 2:
										if ((h[1].twig == 0) & (h[1].stone == 0) & (h[1].dewdrop == 0) & (h[1].leaf == 0))
										{
											flag = 1;
											break; //кучу уничтожил жук-носорог
										}
										if (((h[1].twig - greenWo[po].twig) > 0) & (greenWo[po].twig != 0))
										{
											h[1].twig -= greenWo[po].twig;
											greenres += 1;
											n = 1;
										}
										if (((h[1].stone - greenWo[po].stone) > 0) & (greenWo[po].stone != 0))
										{
											h[1].stone -= greenWo[po].stone;
											greenres += 1;
										}
										if ((greenWo[po].name == "продвинутый неповторимый") & ((h[1].twig - greenWo[po].twig) > 0) & (n == 1))
										{
											h[1].twig -= greenWo[po].twig;
											greenres += 1;
										}
										if ((greenWo[po].name == "продвинутый неповторимый") & ((h[1].twig - greenWo[po].twig) == 0) & (n == 0))
										{
											greenres += 2;
										}
										break;    
									case 3:
										if ((h[2].twig == 0) & (h[2].stone == 0) & (h[2].dewdrop == 0) & (h[2].leaf == 0))
										{
											flag = 1;
											break; //кучу уничтожил жук-носорог
										}
										if (((h[2].twig - greenWo[po].twig) > 0) & (greenWo[po].twig != 0))
										{
											h[2].twig -= greenWo[po].twig;
											greenres += 1;
										}
										if (((h[2].stone - greenWo[po].stone) > 0) & (greenWo[po].stone != 0))
										{
											h[2].stone -= greenWo[po].stone;
											greenres += 1;
										}
										if (((h[2].dewdrop - greenWo[po].dewdrop) > 0) & (greenWo[po].dewdrop != 0))
										{
											h[2].dewdrop -= greenWo[po].dewdrop;
											greenres += 1;
										}
										if ((greenWo[po].name == "продвинутый неповторимый") & ((h[2].twig - greenWo[po].twig) > 0) & (n == 1))
										{
											h[2].twig -= greenWo[po].twig;
											greenres += 1;
										}
										if ((greenWo[po].name == "продвинутый неповторимый") & ((h[2].twig - greenWo[po].twig) == 0) & (n == 0))
										{
											greenres += 2;
										}
										break;
									case 4:
										if ((h[3].twig == 0) & (h[3].stone == 0) & (h[3].dewdrop == 0) & (h[3].leaf == 0))
										{
											flag = 1;
											break; //кучу уничтожил жук-носорог
										}
										if (((h[3].twig - greenWo[po].twig) > 0) & (greenWo[po].twig != 0))
										{
											h[3].twig -= greenWo[po].twig;
											greenres += 1;
										}
										if (((h[3].stone - greenWo[po].stone) > 0) & (greenWo[po].stone != 0))
										{
											h[3].stone -= greenWo[po].stone;
											greenres += 1;
										}
										if ((greenWo[po].name == "продвинутый неповторимый") & ((h[3].twig - greenWo[po].twig) > 0) & (n == 1))
										{
											h[3].twig -= greenWo[po].twig;
											greenres += 1;
										}
										if ((greenWo[po].name == "продвинутый неповторимый") & ((h[3].twig - greenWo[po].twig) == 0) & (n == 0))
										{
											greenres += 2;
										}
										if (((h[3].leaf - greenWo[po].leaf) > 0) & (greenWo[po].leaf != 0))
										{
											h[3].leaf -= greenWo[po].leaf;
											greenres += 1;
										}
										break;
									case 5:
										if ((h[4].twig == 0) & (h[4].stone == 0) & (h[4].dewdrop == 0) & (h[4].leaf == 0))
										{
											flag = 1;
											break; //кучу уничтожил жук-носорог
										}
										if (((h[4].twig - greenWo[po].twig) > 0) & (greenWo[po].twig != 0))
										{
											h[4].twig -= greenWo[po].twig;
											greenres += 1;
										}
										if (((h[4].dewdrop - greenWo[po].dewdrop) > 0) & (greenWo[po].dewdrop != 0))
										{
											h[4].dewdrop -= greenWo[po].dewdrop;
											greenres += 1;
										}
										if ((greenWo[po].name == "продвинутый неповторимый") & ((h[4].twig - greenWo[po].twig) > 0) & (n == 1))
										{
											h[4].twig -= greenWo[po].twig;
											greenres += 1;
										}
										if ((greenWo[po].name == "продвинутый неповторимый") & ((h[4].twig - greenWo[po].twig) == 0) & (n == 0))
										{
											greenres += 2;
										}
										break;
								}
								if (flag == 0)
								{
									Console.WriteLine($"Муравей {greenWo[po].name} из колонии зеленых отправился на кучу {nomerkuchi} и принес ресурсы");
								}
								else
								{
									Console.WriteLine($"Муравей {greenWo[po].name} из колонии зеленых отправился на кучу {nomerkuchi}, но она была УНИЧТОЖЕНА ЖУКОМ-НОСОРОГОМ");
								}
							}
							Console.WriteLine($"\n ИНФОРМАЦИЯ О ПОХОДАХ \n КОЛОНИЯ РЫЖИХ");
							for (int po = 0; po < redWo.Count; po++) // идёт в поход первая колония
							{
								int nomerkuchi = random.Next(1, 6); // определитель в какую кучу пойдёт муравей
								int flag = 0;
								switch (nomerkuchi)
								{
									case 1://идет на кучу 1
										if ((h[0].twig==0)& (h[0].stone == 0)& (h[0].dewdrop == 0)& (h[0].leaf == 0))
										{
											flag = 1;
											break; //кучу уничтожил жук-носорог
										}
										if (((h[0].twig - redWo[po].twig) > 0) & (redWo[po].twig != 0))
										{
											h[0].twig -= redWo[po].twig;
											redres += 1;
										}
										if (redWo[po].name == "продвинутый карманник")
										{
											redres += 1;
											greenres -= 1;
										}

										break;
									case 2:
										if ((h[1].twig == 0) & (h[1].stone == 0) & (h[1].dewdrop == 0) & (h[1].leaf == 0))
										{
											flag = 1;
											break; //кучу уничтожил жук-носорог
										}
										if (((h[1].twig - redWo[po].twig) > 0) & (redWo[po].twig != 0))
										{
											h[1].twig -= redWo[po].twig;
											redres += 1;
										}
										if (((h[1].stone - redWo[po].stone) > 0) & (redWo[po].stone != 0))
										{
											h[1].stone -= redWo[po].stone;
											redres += 1;
										}
										if (redWo[po].name == "продвинутый карманник")
										{
											redres += 1;
											greenres -= 1;
										}

										break;
									case 3:
										if ((h[2].twig == 0) & (h[2].stone == 0) & (h[2].dewdrop == 0) & (h[2].leaf == 0))
										{
											flag = 1;
											break; //кучу уничтожил жук-носорог
										}
										if (((h[2].twig - redWo[po].twig) > 0) & (redWo[po].twig != 0))
										{
											h[2].twig -= redWo[po].twig;
											redres += 1;
										}
										if (((h[2].stone - redWo[po].stone) > 0) & (redWo[po].stone != 0))
										{
											h[2].stone -= redWo[po].stone;
											redres += 1;
										}
										if (((h[2].dewdrop - redWo[po].dewdrop) > 0) & (redWo[po].dewdrop != 0))
										{
											h[2].dewdrop -= redWo[po].dewdrop;
											redres += 1;
										}
										if (redWo[po].name == "продвинутый карманник")
										{
											redres += 1;
											greenres -= 1;
										}

										break;
									case 4:
										if ((h[3].twig == 0) & (h[3].stone == 0) & (h[3].dewdrop == 0) & (h[3].leaf == 0))
										{
											flag = 1;
											break; //кучу уничтожил жук-носорог
										}
										if (((h[3].twig - redWo[po].twig) > 0) & (redWo[po].twig != 0))
										{
											h[3].twig -= redWo[po].twig;
											redres += 1;
										}
										if (((h[3].stone - redWo[po].stone) > 0) & (redWo[po].stone != 0))
										{
											h[3].stone -= redWo[po].stone;
											redres += 1;
										}
										if (redWo[po].name == "легендарный")
										{
											if (((h[3].leaf - redWo[po].leaf) > 0) & (redWo[po].leaf != 0))
											{
												h[3].leaf -= redWo[po].leaf;
												redres += 1;
											}   
										}
										if (redWo[po].name == "продвинутый карманник")
										{
											if ((h[3].leaf - redWo[po].leaf) > 0)
											{
												h[3].leaf -= redWo[po].leaf;
												redres += 1;
											}
											else
											{
												redres += 1;
												greenres -= 1;
											}
										}
										if (((h[3].leaf - redWo[po].leaf) > 0) & (redWo[po].leaf != 0))
										{
											h[3].leaf -= redWo[po].leaf;
											redres += 1;
										}
										break;
									case 5:
										if ((h[4].twig == 0) & (h[4].stone == 0) & (h[4].dewdrop == 0) & (h[4].leaf == 0))
										{
											flag = 1;
											break; //кучу уничтожил жук-носорог
										}
										if (((h[4].twig - redWo[po].twig) > 0) & (redWo[po].twig != 0))
										{
											h[4].twig -= redWo[po].twig;
											redres += 1;
										}
										if (((h[4].dewdrop - redWo[po].dewdrop) > 0) & (redWo[po].dewdrop != 0))
										{
											h[4].dewdrop -= redWo[po].dewdrop;
											redres += 1;
										}
										if (redWo[po].name == "продвинутый карманник")
										{
											redres += 1;
											greenres -= 1;
										}
										break;
								}
								if (flag == 0)
								{
									Console.WriteLine($"Муравей {redWo[po].name} из колонии рыжих отправился на кучу {nomerkuchi} и принес ресурсы");
								}
								else
								{
									Console.WriteLine($"Муравей {redWo[po].name} из колонии рыжих отправился на кучу {nomerkuchi}, но она была УНИЧТОЖЕНА ЖУКОМ-НОСОРОГОМ");
								}
							}
						}
						if (Time == 7) //Приходит Жук-носорог (доп задание) на 1 день с эффектом (происходит 1 раз)
						{
							int del = random.Next(1, 5);
							switch (del)
							{
								case 1:
									h[0].twig = 0;
									Console.WriteLine($"\n <<<<<<Пришел Жук-носорог и удалил кучу 1>>>>>>");
									break;
								case 2:
									h[1].twig = 0;
									h[1].stone = 0;
									Console.WriteLine($"\n <<<<<<Пришел Жук-носорог и удалил кучу 2>>>>>>");
									break;
								case 3:
									h[2].twig = 0;
									h[2].stone = 0;
									h[2].dewdrop = 0;
									Console.WriteLine($"\n <<<<<<Пришел Жук-носорог и удалил кучу 3>>>>>>");
									break;
								case 4:
									h[3].twig = 0;
									h[3].leaf = 0;
									h[3].stone = 0;
									Console.WriteLine($"\n <<<<<<Пришел Жук-носорог и удалил кучу 4>>>>>>");
									break;
								case 5:
									h[4].twig = 0;
									h[4].dewdrop = 0;
									Console.WriteLine($"\n <<<<<<Пришел Жук-носорог и удалил кучу 5>>>>>>");
									break;
							}
						}
							
					Console.ReadKey();
					break;

				}
			}
		}
	}
}

