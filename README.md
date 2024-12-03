Azure service bus Messaging services:
1. Event Grid
   Best suits to reactive programmings (discrete) like triggers in database
3. Event Hub
   as big data pipeline , event streaming not want to miss any data.
   5. Storage Queues : are just queues
      can grow more than 80 GB storage.
6. Service Bus
   * High value enterpresie messaging , order processing ,financial transactions.
   * Unlike storage queues, it supports publish/subscribe,topics and queues.
   * Service queue can grow upto 80GB
   * It guarantee FIFO, support duplicate detection, AMQP protocoal
  
   * Quesques : enable you to storagte messages until the receiving applicaiton is available to receive and process them.
   * Queues: are temporary storage location for messages  and message are delivered in pull mode
   * A receiver picks the message in front of the queue.
   * You can add/remove reciever instances as your queue length changes to the demand and workload
  
    ![image](https://github.com/user-attachments/assets/4d536198-3b1a-4880-a557-3e271ca57475)

