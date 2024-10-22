/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Snowball;
using Amazon.Snowball.Model;

namespace Amazon.PowerShell.Cmdlets.SNOW
{
    /// <summary>
    /// Creates a job to import or export data between Amazon S3 and your on-premises data
    /// center. Your Amazon Web Services account must have the right trust policies and permissions
    /// in place to create a job for a Snow device. If you're creating a job for a node in
    /// a cluster, you only need to provide the <c>clusterId</c> value; the other job attributes
    /// are inherited from the cluster. 
    /// 
    ///  <note><para>
    /// Only the Snowball; Edge device type is supported when ordering clustered jobs.
    /// </para><para>
    /// The device capacity is optional.
    /// </para><para>
    /// Availability of device types differ by Amazon Web Services Region. For more information
    /// about Region availability, see <a href="https://aws.amazon.com/about-aws/global-infrastructure/regional-product-services/?p=ngi&amp;loc=4">Amazon
    /// Web Services Regional Services</a>.
    /// </para></note><para><b>Snow Family devices and their capacities.</b></para><ul><li><para>
    /// Device type: <b>SNC1_SSD</b></para><ul><li><para>
    /// Capacity: T14
    /// </para></li><li><para>
    /// Description: Snowcone 
    /// </para></li></ul></li><li><para>
    /// Device type: <b>SNC1_HDD</b></para><ul><li><para>
    /// Capacity: T8
    /// </para></li><li><para>
    /// Description: Snowcone 
    /// </para></li></ul></li><li><para>
    /// Device type: <b>EDGE_S</b></para><ul><li><para>
    /// Capacity: T98
    /// </para></li><li><para>
    /// Description: Snowball Edge Storage Optimized for data transfer only 
    /// </para></li></ul></li><li><para>
    /// Device type: <b>EDGE_CG</b></para><ul><li><para>
    /// Capacity: T42
    /// </para></li><li><para>
    /// Description: Snowball Edge Compute Optimized with GPU
    /// </para></li></ul></li><li><para>
    /// Device type: <b>EDGE_C</b></para><ul><li><para>
    /// Capacity: T42
    /// </para></li><li><para>
    /// Description: Snowball Edge Compute Optimized without GPU
    /// </para></li></ul></li><li><para>
    /// Device type: <b>EDGE</b></para><ul><li><para>
    /// Capacity: T100
    /// </para></li><li><para>
    /// Description: Snowball Edge Storage Optimized with EC2 Compute
    /// </para></li></ul><note><para>
    /// This device is replaced with T98.
    /// </para></note></li><li><para>
    /// Device type: <b>STANDARD</b></para><ul><li><para>
    /// Capacity: T50
    /// </para></li><li><para>
    /// Description: Original Snowball device
    /// </para><note><para>
    /// This device is only available in the Ningxia, Beijing, and Singapore Amazon Web Services
    /// Region 
    /// </para></note></li></ul></li><li><para>
    /// Device type: <b>STANDARD</b></para><ul><li><para>
    /// Capacity: T80
    /// </para></li><li><para>
    /// Description: Original Snowball device
    /// </para><note><para>
    /// This device is only available in the Ningxia, Beijing, and Singapore Amazon Web Services
    /// Region. 
    /// </para></note></li></ul></li><li><para>
    /// Snow Family device type: <b>RACK_5U_C</b></para><ul><li><para>
    /// Capacity: T13 
    /// </para></li><li><para>
    /// Description: Snowblade.
    /// </para></li></ul></li><li><para>
    /// Device type: <b>V3_5S</b></para><ul><li><para>
    /// Capacity: T240
    /// </para></li><li><para>
    /// Description: Snowball Edge Storage Optimized 210TB
    /// </para></li></ul></li></ul>
    /// </summary>
    [Cmdlet("New", "SNOWJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Import/Export Snowball CreateJob API operation.", Operation = new[] {"CreateJob"}, SelectReturnType = typeof(Amazon.Snowball.Model.CreateJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.Snowball.Model.CreateJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Snowball.Model.CreateJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSNOWJobCmdlet : AmazonSnowballClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AddressId
        /// <summary>
        /// <para>
        /// <para>The ID for the address that you want the Snow device shipped to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AddressId { get; set; }
        #endregion
        
        #region Parameter ClusterId
        /// <summary>
        /// <para>
        /// <para>The ID of a cluster. If you're creating a job for a node in a cluster, you need to
        /// provide only this <c>clusterId</c> value. The other job attributes are inherited from
        /// the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClusterId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Defines an optional description of this specific job, for example <c>Important Photos
        /// 2016-08-11</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter PickupDetails_DevicePickupId
        /// <summary>
        /// <para>
        /// <para>The unique ID for a device that will be picked up.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PickupDetails_DevicePickupId { get; set; }
        #endregion
        
        #region Parameter Notification_DevicePickupSnsTopicARN
        /// <summary>
        /// <para>
        /// <para>Used to send SNS notifications for the person picking up the device (identified during
        /// job creation).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Notification_DevicePickupSnsTopicARN { get; set; }
        #endregion
        
        #region Parameter Resources_Ec2AmiResource
        /// <summary>
        /// <para>
        /// <para>The Amazon Machine Images (AMIs) associated with this job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resources_Ec2AmiResources")]
        public Amazon.Snowball.Model.Ec2AmiResource[] Resources_Ec2AmiResource { get; set; }
        #endregion
        
        #region Parameter EKSOnDeviceService_EKSAnywhereVersion
        /// <summary>
        /// <para>
        /// <para>The optional version of EKS Anywhere on the Snow Family device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnDeviceServiceConfiguration_EKSOnDeviceService_EKSAnywhereVersion")]
        public System.String EKSOnDeviceService_EKSAnywhereVersion { get; set; }
        #endregion
        
        #region Parameter PickupDetails_Email
        /// <summary>
        /// <para>
        /// <para>The email address of the person picking up the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PickupDetails_Email { get; set; }
        #endregion
        
        #region Parameter S3OnDeviceService_FaultTolerance
        /// <summary>
        /// <para>
        /// <para>&gt;Fault tolerance level of the cluster. This indicates the number of nodes that
        /// can go down without degrading the performance of the cluster. This additional input
        /// helps when the specified <c>StorageLimit</c> matches more than one Amazon S3 compatible
        /// storage on Snow family devices service configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnDeviceServiceConfiguration_S3OnDeviceService_FaultTolerance")]
        public System.Int32? S3OnDeviceService_FaultTolerance { get; set; }
        #endregion
        
        #region Parameter ForwardingAddressId
        /// <summary>
        /// <para>
        /// <para>The forwarding address ID for a job. This field is not supported in most Regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ForwardingAddressId { get; set; }
        #endregion
        
        #region Parameter IND_GSTIN
        /// <summary>
        /// <para>
        /// <para>The Goods and Services Tax (GST) documents required in Amazon Web Services Region
        /// in India.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxDocuments_IND_GSTIN")]
        public System.String IND_GSTIN { get; set; }
        #endregion
        
        #region Parameter PickupDetails_IdentificationExpirationDate
        /// <summary>
        /// <para>
        /// <para>Expiration date of the credential identifying the person picking up the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? PickupDetails_IdentificationExpirationDate { get; set; }
        #endregion
        
        #region Parameter PickupDetails_IdentificationIssuingOrg
        /// <summary>
        /// <para>
        /// <para>Organization that issued the credential identifying the person picking up the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PickupDetails_IdentificationIssuingOrg { get; set; }
        #endregion
        
        #region Parameter PickupDetails_IdentificationNumber
        /// <summary>
        /// <para>
        /// <para>The number on the credential identifying the person picking up the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PickupDetails_IdentificationNumber { get; set; }
        #endregion
        
        #region Parameter ImpactLevel
        /// <summary>
        /// <para>
        /// <para>The highest impact level of data that will be stored or processed on the device, provided
        /// at job creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Snowball.ImpactLevel")]
        public Amazon.Snowball.ImpactLevel ImpactLevel { get; set; }
        #endregion
        
        #region Parameter WirelessConnection_IsWifiEnabled
        /// <summary>
        /// <para>
        /// <para>Enables the Wi-Fi adapter on an Snowcone device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeviceConfiguration_SnowconeDeviceConfiguration_WirelessConnection_IsWifiEnabled")]
        public System.Boolean? WirelessConnection_IsWifiEnabled { get; set; }
        #endregion
        
        #region Parameter Notification_JobStatesToNotify
        /// <summary>
        /// <para>
        /// <para>The list of job states that will trigger a notification for this job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Notification_JobStatesToNotify { get; set; }
        #endregion
        
        #region Parameter JobType
        /// <summary>
        /// <para>
        /// <para>Defines the type of job that you're creating. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Snowball.JobType")]
        public Amazon.Snowball.JobType JobType { get; set; }
        #endregion
        
        #region Parameter KmsKeyARN
        /// <summary>
        /// <para>
        /// <para>The <c>KmsKeyARN</c> that you want to associate with this job. <c>KmsKeyARN</c>s are
        /// created using the <a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_CreateKey.html">CreateKey</a>
        /// Key Management Service (KMS) API action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyARN { get; set; }
        #endregion
        
        #region Parameter EKSOnDeviceService_KubernetesVersion
        /// <summary>
        /// <para>
        /// <para>The Kubernetes version for EKS Anywhere on the Snow Family device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnDeviceServiceConfiguration_EKSOnDeviceService_KubernetesVersion")]
        public System.String EKSOnDeviceService_KubernetesVersion { get; set; }
        #endregion
        
        #region Parameter Resources_LambdaResource
        /// <summary>
        /// <para>
        /// <para>The Python-language Lambda functions for this job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resources_LambdaResources")]
        public Amazon.Snowball.Model.LambdaResource[] Resources_LambdaResource { get; set; }
        #endregion
        
        #region Parameter LongTermPricingId
        /// <summary>
        /// <para>
        /// <para>The ID of the long-term pricing type for the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LongTermPricingId { get; set; }
        #endregion
        
        #region Parameter PickupDetails_Name
        /// <summary>
        /// <para>
        /// <para>The name of the person picking up the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PickupDetails_Name { get; set; }
        #endregion
        
        #region Parameter Notification_NotifyAll
        /// <summary>
        /// <para>
        /// <para>Any change in job state will trigger a notification for this job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Notification_NotifyAll { get; set; }
        #endregion
        
        #region Parameter PickupDetails_PhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number of the person picking up the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PickupDetails_PhoneNumber { get; set; }
        #endregion
        
        #region Parameter RemoteManagement
        /// <summary>
        /// <para>
        /// <para>Allows you to securely operate and manage Snowcone devices remotely from outside of
        /// your internal network. When set to <c>INSTALLED_AUTOSTART</c>, remote management will
        /// automatically be available when the device arrives at your location. Otherwise, you
        /// need to use the Snowball Edge client to manage the device. When set to <c>NOT_INSTALLED</c>,
        /// remote management will not be available on the device. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Snowball.RemoteManagement")]
        public Amazon.Snowball.RemoteManagement RemoteManagement { get; set; }
        #endregion
        
        #region Parameter RoleARN
        /// <summary>
        /// <para>
        /// <para>The <c>RoleARN</c> that you want to associate with this job. <c>RoleArn</c>s are created
        /// using the <a href="https://docs.aws.amazon.com/IAM/latest/APIReference/API_CreateRole.html">CreateRole</a>
        /// Identity and Access Management (IAM) API action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleARN { get; set; }
        #endregion
        
        #region Parameter Resources_S3Resource
        /// <summary>
        /// <para>
        /// <para>An array of <c>S3Resource</c> objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resources_S3Resources")]
        public Amazon.Snowball.Model.S3Resource[] Resources_S3Resource { get; set; }
        #endregion
        
        #region Parameter S3OnDeviceService_ServiceSize
        /// <summary>
        /// <para>
        /// <para>Applicable when creating a cluster. Specifies how many nodes are needed for Amazon
        /// S3 compatible storage on Snow family devices. If specified, the other input can be
        /// omitted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnDeviceServiceConfiguration_S3OnDeviceService_ServiceSize")]
        public System.Int32? S3OnDeviceService_ServiceSize { get; set; }
        #endregion
        
        #region Parameter ShippingOption
        /// <summary>
        /// <para>
        /// <para>The shipping speed for this job. This speed doesn't dictate how soon you'll get the
        /// Snow device, rather it represents how quickly the Snow device moves to its destination
        /// while in transit. Regional shipping speeds are as follows:</para><ul><li><para>In Australia, you have access to express shipping. Typically, Snow devices shipped
        /// express are delivered in about a day.</para></li><li><para>In the European Union (EU), you have access to express shipping. Typically, Snow devices
        /// shipped express are delivered in about a day. In addition, most countries in the EU
        /// have access to standard shipping, which typically takes less than a week, one way.</para></li><li><para>In India, Snow devices are delivered in one to seven days.</para></li><li><para>In the US, you have access to one-day shipping and two-day shipping.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Snowball.ShippingOption")]
        public Amazon.Snowball.ShippingOption ShippingOption { get; set; }
        #endregion
        
        #region Parameter SnowballCapacityPreference
        /// <summary>
        /// <para>
        /// <para>If your job is being created in one of the US regions, you have the option of specifying
        /// what size Snow device you'd like for this job. In all other regions, Snowballs come
        /// with 80 TB in storage capacity.</para><para>For more information, see "https://docs.aws.amazon.com/snowball/latest/snowcone-guide/snow-device-types.html"
        /// (Snow Family Devices and Capacity) in the <i>Snowcone User Guide</i> or "https://docs.aws.amazon.com/snowball/latest/developer-guide/snow-device-types.html"
        /// (Snow Family Devices and Capacity) in the <i>Snowcone User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Snowball.SnowballCapacity")]
        public Amazon.Snowball.SnowballCapacity SnowballCapacityPreference { get; set; }
        #endregion
        
        #region Parameter SnowballType
        /// <summary>
        /// <para>
        /// <para>The type of Snow Family devices to use for this job. </para><note><para>For cluster jobs, Amazon Web Services Snow Family currently supports only the <c>EDGE</c>
        /// device type.</para></note><para>The type of Amazon Web Services Snow device to use for this job. Currently, the only
        /// supported device type for cluster jobs is <c>EDGE</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/snowball/latest/developer-guide/device-differences.html">Snowball
        /// Edge Device Options</a> in the Snowball Edge Developer Guide.</para><para>For more information, see "https://docs.aws.amazon.com/snowball/latest/snowcone-guide/snow-device-types.html"
        /// (Snow Family Devices and Capacity) in the <i>Snowcone User Guide</i> or "https://docs.aws.amazon.com/snowball/latest/developer-guide/snow-device-types.html"
        /// (Snow Family Devices and Capacity) in the <i>Snowcone User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Snowball.SnowballType")]
        public Amazon.Snowball.SnowballType SnowballType { get; set; }
        #endregion
        
        #region Parameter Notification_SnsTopicARN
        /// <summary>
        /// <para>
        /// <para>The new SNS <c>TopicArn</c> that you want to associate with this job. You can create
        /// Amazon Resource Names (ARNs) for topics by using the <a href="https://docs.aws.amazon.com/sns/latest/api/API_CreateTopic.html">CreateTopic</a>
        /// Amazon SNS API action.</para><para>You can subscribe email addresses to an Amazon SNS topic through the Amazon Web Services
        /// Management Console, or by using the <a href="https://docs.aws.amazon.com/sns/latest/api/API_Subscribe.html">Subscribe</a>
        /// Amazon Simple Notification Service (Amazon SNS) API action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Notification_SnsTopicARN { get; set; }
        #endregion
        
        #region Parameter NFSOnDeviceService_StorageLimit
        /// <summary>
        /// <para>
        /// <para>The maximum NFS storage for one Snow Family device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnDeviceServiceConfiguration_NFSOnDeviceService_StorageLimit")]
        public System.Int32? NFSOnDeviceService_StorageLimit { get; set; }
        #endregion
        
        #region Parameter S3OnDeviceService_StorageLimit
        /// <summary>
        /// <para>
        /// <para>If the specified storage limit value matches storage limit of one of the defined configurations,
        /// that configuration will be used. If the specified storage limit value does not match
        /// any defined configuration, the request will fail. If more than one configuration has
        /// the same storage limit as specified, the other input need to be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnDeviceServiceConfiguration_S3OnDeviceService_StorageLimit")]
        public System.Double? S3OnDeviceService_StorageLimit { get; set; }
        #endregion
        
        #region Parameter TGWOnDeviceService_StorageLimit
        /// <summary>
        /// <para>
        /// <para>The maximum number of virtual tapes to store on one Snow Family device. Due to physical
        /// resource limitations, this value must be set to 80 for Snowball Edge.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnDeviceServiceConfiguration_TGWOnDeviceService_StorageLimit")]
        public System.Int32? TGWOnDeviceService_StorageLimit { get; set; }
        #endregion
        
        #region Parameter NFSOnDeviceService_StorageUnit
        /// <summary>
        /// <para>
        /// <para>The scale unit of the NFS storage on the device.</para><para>Valid values: TB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnDeviceServiceConfiguration_NFSOnDeviceService_StorageUnit")]
        [AWSConstantClassSource("Amazon.Snowball.StorageUnit")]
        public Amazon.Snowball.StorageUnit NFSOnDeviceService_StorageUnit { get; set; }
        #endregion
        
        #region Parameter S3OnDeviceService_StorageUnit
        /// <summary>
        /// <para>
        /// <para>Storage unit. Currently the only supported unit is TB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnDeviceServiceConfiguration_S3OnDeviceService_StorageUnit")]
        [AWSConstantClassSource("Amazon.Snowball.StorageUnit")]
        public Amazon.Snowball.StorageUnit S3OnDeviceService_StorageUnit { get; set; }
        #endregion
        
        #region Parameter TGWOnDeviceService_StorageUnit
        /// <summary>
        /// <para>
        /// <para>The scale unit of the virtual tapes on the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnDeviceServiceConfiguration_TGWOnDeviceService_StorageUnit")]
        [AWSConstantClassSource("Amazon.Snowball.StorageUnit")]
        public Amazon.Snowball.StorageUnit TGWOnDeviceService_StorageUnit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Snowball.Model.CreateJobResponse).
        /// Specifying the name of a property of type Amazon.Snowball.Model.CreateJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobId";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AddressId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SNOWJob (CreateJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Snowball.Model.CreateJobResponse, NewSNOWJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AddressId = this.AddressId;
            context.ClusterId = this.ClusterId;
            context.Description = this.Description;
            context.WirelessConnection_IsWifiEnabled = this.WirelessConnection_IsWifiEnabled;
            context.ForwardingAddressId = this.ForwardingAddressId;
            context.ImpactLevel = this.ImpactLevel;
            context.JobType = this.JobType;
            context.KmsKeyARN = this.KmsKeyARN;
            context.LongTermPricingId = this.LongTermPricingId;
            context.Notification_DevicePickupSnsTopicARN = this.Notification_DevicePickupSnsTopicARN;
            if (this.Notification_JobStatesToNotify != null)
            {
                context.Notification_JobStatesToNotify = new List<System.String>(this.Notification_JobStatesToNotify);
            }
            context.Notification_NotifyAll = this.Notification_NotifyAll;
            context.Notification_SnsTopicARN = this.Notification_SnsTopicARN;
            context.EKSOnDeviceService_EKSAnywhereVersion = this.EKSOnDeviceService_EKSAnywhereVersion;
            context.EKSOnDeviceService_KubernetesVersion = this.EKSOnDeviceService_KubernetesVersion;
            context.NFSOnDeviceService_StorageLimit = this.NFSOnDeviceService_StorageLimit;
            context.NFSOnDeviceService_StorageUnit = this.NFSOnDeviceService_StorageUnit;
            context.S3OnDeviceService_FaultTolerance = this.S3OnDeviceService_FaultTolerance;
            context.S3OnDeviceService_ServiceSize = this.S3OnDeviceService_ServiceSize;
            context.S3OnDeviceService_StorageLimit = this.S3OnDeviceService_StorageLimit;
            context.S3OnDeviceService_StorageUnit = this.S3OnDeviceService_StorageUnit;
            context.TGWOnDeviceService_StorageLimit = this.TGWOnDeviceService_StorageLimit;
            context.TGWOnDeviceService_StorageUnit = this.TGWOnDeviceService_StorageUnit;
            context.PickupDetails_DevicePickupId = this.PickupDetails_DevicePickupId;
            context.PickupDetails_Email = this.PickupDetails_Email;
            context.PickupDetails_IdentificationExpirationDate = this.PickupDetails_IdentificationExpirationDate;
            context.PickupDetails_IdentificationIssuingOrg = this.PickupDetails_IdentificationIssuingOrg;
            context.PickupDetails_IdentificationNumber = this.PickupDetails_IdentificationNumber;
            context.PickupDetails_Name = this.PickupDetails_Name;
            context.PickupDetails_PhoneNumber = this.PickupDetails_PhoneNumber;
            context.RemoteManagement = this.RemoteManagement;
            if (this.Resources_Ec2AmiResource != null)
            {
                context.Resources_Ec2AmiResource = new List<Amazon.Snowball.Model.Ec2AmiResource>(this.Resources_Ec2AmiResource);
            }
            if (this.Resources_LambdaResource != null)
            {
                context.Resources_LambdaResource = new List<Amazon.Snowball.Model.LambdaResource>(this.Resources_LambdaResource);
            }
            if (this.Resources_S3Resource != null)
            {
                context.Resources_S3Resource = new List<Amazon.Snowball.Model.S3Resource>(this.Resources_S3Resource);
            }
            context.RoleARN = this.RoleARN;
            context.ShippingOption = this.ShippingOption;
            context.SnowballCapacityPreference = this.SnowballCapacityPreference;
            context.SnowballType = this.SnowballType;
            context.IND_GSTIN = this.IND_GSTIN;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Snowball.Model.CreateJobRequest();
            
            if (cmdletContext.AddressId != null)
            {
                request.AddressId = cmdletContext.AddressId;
            }
            if (cmdletContext.ClusterId != null)
            {
                request.ClusterId = cmdletContext.ClusterId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate DeviceConfiguration
            var requestDeviceConfigurationIsNull = true;
            request.DeviceConfiguration = new Amazon.Snowball.Model.DeviceConfiguration();
            Amazon.Snowball.Model.SnowconeDeviceConfiguration requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration = null;
            
             // populate SnowconeDeviceConfiguration
            var requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfigurationIsNull = true;
            requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration = new Amazon.Snowball.Model.SnowconeDeviceConfiguration();
            Amazon.Snowball.Model.WirelessConnection requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_WirelessConnection = null;
            
             // populate WirelessConnection
            var requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_WirelessConnectionIsNull = true;
            requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_WirelessConnection = new Amazon.Snowball.Model.WirelessConnection();
            System.Boolean? requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_WirelessConnection_wirelessConnection_IsWifiEnabled = null;
            if (cmdletContext.WirelessConnection_IsWifiEnabled != null)
            {
                requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_WirelessConnection_wirelessConnection_IsWifiEnabled = cmdletContext.WirelessConnection_IsWifiEnabled.Value;
            }
            if (requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_WirelessConnection_wirelessConnection_IsWifiEnabled != null)
            {
                requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_WirelessConnection.IsWifiEnabled = requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_WirelessConnection_wirelessConnection_IsWifiEnabled.Value;
                requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_WirelessConnectionIsNull = false;
            }
             // determine if requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_WirelessConnection should be set to null
            if (requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_WirelessConnectionIsNull)
            {
                requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_WirelessConnection = null;
            }
            if (requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_WirelessConnection != null)
            {
                requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration.WirelessConnection = requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration_WirelessConnection;
                requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfigurationIsNull = false;
            }
             // determine if requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration should be set to null
            if (requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfigurationIsNull)
            {
                requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration = null;
            }
            if (requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration != null)
            {
                request.DeviceConfiguration.SnowconeDeviceConfiguration = requestDeviceConfiguration_deviceConfiguration_SnowconeDeviceConfiguration;
                requestDeviceConfigurationIsNull = false;
            }
             // determine if request.DeviceConfiguration should be set to null
            if (requestDeviceConfigurationIsNull)
            {
                request.DeviceConfiguration = null;
            }
            if (cmdletContext.ForwardingAddressId != null)
            {
                request.ForwardingAddressId = cmdletContext.ForwardingAddressId;
            }
            if (cmdletContext.ImpactLevel != null)
            {
                request.ImpactLevel = cmdletContext.ImpactLevel;
            }
            if (cmdletContext.JobType != null)
            {
                request.JobType = cmdletContext.JobType;
            }
            if (cmdletContext.KmsKeyARN != null)
            {
                request.KmsKeyARN = cmdletContext.KmsKeyARN;
            }
            if (cmdletContext.LongTermPricingId != null)
            {
                request.LongTermPricingId = cmdletContext.LongTermPricingId;
            }
            
             // populate Notification
            var requestNotificationIsNull = true;
            request.Notification = new Amazon.Snowball.Model.Notification();
            System.String requestNotification_notification_DevicePickupSnsTopicARN = null;
            if (cmdletContext.Notification_DevicePickupSnsTopicARN != null)
            {
                requestNotification_notification_DevicePickupSnsTopicARN = cmdletContext.Notification_DevicePickupSnsTopicARN;
            }
            if (requestNotification_notification_DevicePickupSnsTopicARN != null)
            {
                request.Notification.DevicePickupSnsTopicARN = requestNotification_notification_DevicePickupSnsTopicARN;
                requestNotificationIsNull = false;
            }
            List<System.String> requestNotification_notification_JobStatesToNotify = null;
            if (cmdletContext.Notification_JobStatesToNotify != null)
            {
                requestNotification_notification_JobStatesToNotify = cmdletContext.Notification_JobStatesToNotify;
            }
            if (requestNotification_notification_JobStatesToNotify != null)
            {
                request.Notification.JobStatesToNotify = requestNotification_notification_JobStatesToNotify;
                requestNotificationIsNull = false;
            }
            System.Boolean? requestNotification_notification_NotifyAll = null;
            if (cmdletContext.Notification_NotifyAll != null)
            {
                requestNotification_notification_NotifyAll = cmdletContext.Notification_NotifyAll.Value;
            }
            if (requestNotification_notification_NotifyAll != null)
            {
                request.Notification.NotifyAll = requestNotification_notification_NotifyAll.Value;
                requestNotificationIsNull = false;
            }
            System.String requestNotification_notification_SnsTopicARN = null;
            if (cmdletContext.Notification_SnsTopicARN != null)
            {
                requestNotification_notification_SnsTopicARN = cmdletContext.Notification_SnsTopicARN;
            }
            if (requestNotification_notification_SnsTopicARN != null)
            {
                request.Notification.SnsTopicARN = requestNotification_notification_SnsTopicARN;
                requestNotificationIsNull = false;
            }
             // determine if request.Notification should be set to null
            if (requestNotificationIsNull)
            {
                request.Notification = null;
            }
            
             // populate OnDeviceServiceConfiguration
            var requestOnDeviceServiceConfigurationIsNull = true;
            request.OnDeviceServiceConfiguration = new Amazon.Snowball.Model.OnDeviceServiceConfiguration();
            Amazon.Snowball.Model.EKSOnDeviceServiceConfiguration requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_EKSOnDeviceService = null;
            
             // populate EKSOnDeviceService
            var requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_EKSOnDeviceServiceIsNull = true;
            requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_EKSOnDeviceService = new Amazon.Snowball.Model.EKSOnDeviceServiceConfiguration();
            System.String requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_EKSOnDeviceService_eKSOnDeviceService_EKSAnywhereVersion = null;
            if (cmdletContext.EKSOnDeviceService_EKSAnywhereVersion != null)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_EKSOnDeviceService_eKSOnDeviceService_EKSAnywhereVersion = cmdletContext.EKSOnDeviceService_EKSAnywhereVersion;
            }
            if (requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_EKSOnDeviceService_eKSOnDeviceService_EKSAnywhereVersion != null)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_EKSOnDeviceService.EKSAnywhereVersion = requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_EKSOnDeviceService_eKSOnDeviceService_EKSAnywhereVersion;
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_EKSOnDeviceServiceIsNull = false;
            }
            System.String requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_EKSOnDeviceService_eKSOnDeviceService_KubernetesVersion = null;
            if (cmdletContext.EKSOnDeviceService_KubernetesVersion != null)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_EKSOnDeviceService_eKSOnDeviceService_KubernetesVersion = cmdletContext.EKSOnDeviceService_KubernetesVersion;
            }
            if (requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_EKSOnDeviceService_eKSOnDeviceService_KubernetesVersion != null)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_EKSOnDeviceService.KubernetesVersion = requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_EKSOnDeviceService_eKSOnDeviceService_KubernetesVersion;
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_EKSOnDeviceServiceIsNull = false;
            }
             // determine if requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_EKSOnDeviceService should be set to null
            if (requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_EKSOnDeviceServiceIsNull)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_EKSOnDeviceService = null;
            }
            if (requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_EKSOnDeviceService != null)
            {
                request.OnDeviceServiceConfiguration.EKSOnDeviceService = requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_EKSOnDeviceService;
                requestOnDeviceServiceConfigurationIsNull = false;
            }
            Amazon.Snowball.Model.NFSOnDeviceServiceConfiguration requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_NFSOnDeviceService = null;
            
             // populate NFSOnDeviceService
            var requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_NFSOnDeviceServiceIsNull = true;
            requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_NFSOnDeviceService = new Amazon.Snowball.Model.NFSOnDeviceServiceConfiguration();
            System.Int32? requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_NFSOnDeviceService_nFSOnDeviceService_StorageLimit = null;
            if (cmdletContext.NFSOnDeviceService_StorageLimit != null)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_NFSOnDeviceService_nFSOnDeviceService_StorageLimit = cmdletContext.NFSOnDeviceService_StorageLimit.Value;
            }
            if (requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_NFSOnDeviceService_nFSOnDeviceService_StorageLimit != null)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_NFSOnDeviceService.StorageLimit = requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_NFSOnDeviceService_nFSOnDeviceService_StorageLimit.Value;
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_NFSOnDeviceServiceIsNull = false;
            }
            Amazon.Snowball.StorageUnit requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_NFSOnDeviceService_nFSOnDeviceService_StorageUnit = null;
            if (cmdletContext.NFSOnDeviceService_StorageUnit != null)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_NFSOnDeviceService_nFSOnDeviceService_StorageUnit = cmdletContext.NFSOnDeviceService_StorageUnit;
            }
            if (requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_NFSOnDeviceService_nFSOnDeviceService_StorageUnit != null)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_NFSOnDeviceService.StorageUnit = requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_NFSOnDeviceService_nFSOnDeviceService_StorageUnit;
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_NFSOnDeviceServiceIsNull = false;
            }
             // determine if requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_NFSOnDeviceService should be set to null
            if (requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_NFSOnDeviceServiceIsNull)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_NFSOnDeviceService = null;
            }
            if (requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_NFSOnDeviceService != null)
            {
                request.OnDeviceServiceConfiguration.NFSOnDeviceService = requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_NFSOnDeviceService;
                requestOnDeviceServiceConfigurationIsNull = false;
            }
            Amazon.Snowball.Model.TGWOnDeviceServiceConfiguration requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_TGWOnDeviceService = null;
            
             // populate TGWOnDeviceService
            var requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_TGWOnDeviceServiceIsNull = true;
            requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_TGWOnDeviceService = new Amazon.Snowball.Model.TGWOnDeviceServiceConfiguration();
            System.Int32? requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_TGWOnDeviceService_tGWOnDeviceService_StorageLimit = null;
            if (cmdletContext.TGWOnDeviceService_StorageLimit != null)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_TGWOnDeviceService_tGWOnDeviceService_StorageLimit = cmdletContext.TGWOnDeviceService_StorageLimit.Value;
            }
            if (requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_TGWOnDeviceService_tGWOnDeviceService_StorageLimit != null)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_TGWOnDeviceService.StorageLimit = requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_TGWOnDeviceService_tGWOnDeviceService_StorageLimit.Value;
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_TGWOnDeviceServiceIsNull = false;
            }
            Amazon.Snowball.StorageUnit requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_TGWOnDeviceService_tGWOnDeviceService_StorageUnit = null;
            if (cmdletContext.TGWOnDeviceService_StorageUnit != null)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_TGWOnDeviceService_tGWOnDeviceService_StorageUnit = cmdletContext.TGWOnDeviceService_StorageUnit;
            }
            if (requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_TGWOnDeviceService_tGWOnDeviceService_StorageUnit != null)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_TGWOnDeviceService.StorageUnit = requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_TGWOnDeviceService_tGWOnDeviceService_StorageUnit;
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_TGWOnDeviceServiceIsNull = false;
            }
             // determine if requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_TGWOnDeviceService should be set to null
            if (requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_TGWOnDeviceServiceIsNull)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_TGWOnDeviceService = null;
            }
            if (requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_TGWOnDeviceService != null)
            {
                request.OnDeviceServiceConfiguration.TGWOnDeviceService = requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_TGWOnDeviceService;
                requestOnDeviceServiceConfigurationIsNull = false;
            }
            Amazon.Snowball.Model.S3OnDeviceServiceConfiguration requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService = null;
            
             // populate S3OnDeviceService
            var requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceServiceIsNull = true;
            requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService = new Amazon.Snowball.Model.S3OnDeviceServiceConfiguration();
            System.Int32? requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService_s3OnDeviceService_FaultTolerance = null;
            if (cmdletContext.S3OnDeviceService_FaultTolerance != null)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService_s3OnDeviceService_FaultTolerance = cmdletContext.S3OnDeviceService_FaultTolerance.Value;
            }
            if (requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService_s3OnDeviceService_FaultTolerance != null)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService.FaultTolerance = requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService_s3OnDeviceService_FaultTolerance.Value;
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceServiceIsNull = false;
            }
            System.Int32? requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService_s3OnDeviceService_ServiceSize = null;
            if (cmdletContext.S3OnDeviceService_ServiceSize != null)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService_s3OnDeviceService_ServiceSize = cmdletContext.S3OnDeviceService_ServiceSize.Value;
            }
            if (requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService_s3OnDeviceService_ServiceSize != null)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService.ServiceSize = requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService_s3OnDeviceService_ServiceSize.Value;
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceServiceIsNull = false;
            }
            System.Double? requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService_s3OnDeviceService_StorageLimit = null;
            if (cmdletContext.S3OnDeviceService_StorageLimit != null)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService_s3OnDeviceService_StorageLimit = cmdletContext.S3OnDeviceService_StorageLimit.Value;
            }
            if (requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService_s3OnDeviceService_StorageLimit != null)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService.StorageLimit = requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService_s3OnDeviceService_StorageLimit.Value;
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceServiceIsNull = false;
            }
            Amazon.Snowball.StorageUnit requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService_s3OnDeviceService_StorageUnit = null;
            if (cmdletContext.S3OnDeviceService_StorageUnit != null)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService_s3OnDeviceService_StorageUnit = cmdletContext.S3OnDeviceService_StorageUnit;
            }
            if (requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService_s3OnDeviceService_StorageUnit != null)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService.StorageUnit = requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService_s3OnDeviceService_StorageUnit;
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceServiceIsNull = false;
            }
             // determine if requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService should be set to null
            if (requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceServiceIsNull)
            {
                requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService = null;
            }
            if (requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService != null)
            {
                request.OnDeviceServiceConfiguration.S3OnDeviceService = requestOnDeviceServiceConfiguration_onDeviceServiceConfiguration_S3OnDeviceService;
                requestOnDeviceServiceConfigurationIsNull = false;
            }
             // determine if request.OnDeviceServiceConfiguration should be set to null
            if (requestOnDeviceServiceConfigurationIsNull)
            {
                request.OnDeviceServiceConfiguration = null;
            }
            
             // populate PickupDetails
            var requestPickupDetailsIsNull = true;
            request.PickupDetails = new Amazon.Snowball.Model.PickupDetails();
            System.String requestPickupDetails_pickupDetails_DevicePickupId = null;
            if (cmdletContext.PickupDetails_DevicePickupId != null)
            {
                requestPickupDetails_pickupDetails_DevicePickupId = cmdletContext.PickupDetails_DevicePickupId;
            }
            if (requestPickupDetails_pickupDetails_DevicePickupId != null)
            {
                request.PickupDetails.DevicePickupId = requestPickupDetails_pickupDetails_DevicePickupId;
                requestPickupDetailsIsNull = false;
            }
            System.String requestPickupDetails_pickupDetails_Email = null;
            if (cmdletContext.PickupDetails_Email != null)
            {
                requestPickupDetails_pickupDetails_Email = cmdletContext.PickupDetails_Email;
            }
            if (requestPickupDetails_pickupDetails_Email != null)
            {
                request.PickupDetails.Email = requestPickupDetails_pickupDetails_Email;
                requestPickupDetailsIsNull = false;
            }
            System.DateTime? requestPickupDetails_pickupDetails_IdentificationExpirationDate = null;
            if (cmdletContext.PickupDetails_IdentificationExpirationDate != null)
            {
                requestPickupDetails_pickupDetails_IdentificationExpirationDate = cmdletContext.PickupDetails_IdentificationExpirationDate.Value;
            }
            if (requestPickupDetails_pickupDetails_IdentificationExpirationDate != null)
            {
                request.PickupDetails.IdentificationExpirationDate = requestPickupDetails_pickupDetails_IdentificationExpirationDate.Value;
                requestPickupDetailsIsNull = false;
            }
            System.String requestPickupDetails_pickupDetails_IdentificationIssuingOrg = null;
            if (cmdletContext.PickupDetails_IdentificationIssuingOrg != null)
            {
                requestPickupDetails_pickupDetails_IdentificationIssuingOrg = cmdletContext.PickupDetails_IdentificationIssuingOrg;
            }
            if (requestPickupDetails_pickupDetails_IdentificationIssuingOrg != null)
            {
                request.PickupDetails.IdentificationIssuingOrg = requestPickupDetails_pickupDetails_IdentificationIssuingOrg;
                requestPickupDetailsIsNull = false;
            }
            System.String requestPickupDetails_pickupDetails_IdentificationNumber = null;
            if (cmdletContext.PickupDetails_IdentificationNumber != null)
            {
                requestPickupDetails_pickupDetails_IdentificationNumber = cmdletContext.PickupDetails_IdentificationNumber;
            }
            if (requestPickupDetails_pickupDetails_IdentificationNumber != null)
            {
                request.PickupDetails.IdentificationNumber = requestPickupDetails_pickupDetails_IdentificationNumber;
                requestPickupDetailsIsNull = false;
            }
            System.String requestPickupDetails_pickupDetails_Name = null;
            if (cmdletContext.PickupDetails_Name != null)
            {
                requestPickupDetails_pickupDetails_Name = cmdletContext.PickupDetails_Name;
            }
            if (requestPickupDetails_pickupDetails_Name != null)
            {
                request.PickupDetails.Name = requestPickupDetails_pickupDetails_Name;
                requestPickupDetailsIsNull = false;
            }
            System.String requestPickupDetails_pickupDetails_PhoneNumber = null;
            if (cmdletContext.PickupDetails_PhoneNumber != null)
            {
                requestPickupDetails_pickupDetails_PhoneNumber = cmdletContext.PickupDetails_PhoneNumber;
            }
            if (requestPickupDetails_pickupDetails_PhoneNumber != null)
            {
                request.PickupDetails.PhoneNumber = requestPickupDetails_pickupDetails_PhoneNumber;
                requestPickupDetailsIsNull = false;
            }
             // determine if request.PickupDetails should be set to null
            if (requestPickupDetailsIsNull)
            {
                request.PickupDetails = null;
            }
            if (cmdletContext.RemoteManagement != null)
            {
                request.RemoteManagement = cmdletContext.RemoteManagement;
            }
            
             // populate Resources
            var requestResourcesIsNull = true;
            request.Resources = new Amazon.Snowball.Model.JobResource();
            List<Amazon.Snowball.Model.Ec2AmiResource> requestResources_resources_Ec2AmiResource = null;
            if (cmdletContext.Resources_Ec2AmiResource != null)
            {
                requestResources_resources_Ec2AmiResource = cmdletContext.Resources_Ec2AmiResource;
            }
            if (requestResources_resources_Ec2AmiResource != null)
            {
                request.Resources.Ec2AmiResources = requestResources_resources_Ec2AmiResource;
                requestResourcesIsNull = false;
            }
            List<Amazon.Snowball.Model.LambdaResource> requestResources_resources_LambdaResource = null;
            if (cmdletContext.Resources_LambdaResource != null)
            {
                requestResources_resources_LambdaResource = cmdletContext.Resources_LambdaResource;
            }
            if (requestResources_resources_LambdaResource != null)
            {
                request.Resources.LambdaResources = requestResources_resources_LambdaResource;
                requestResourcesIsNull = false;
            }
            List<Amazon.Snowball.Model.S3Resource> requestResources_resources_S3Resource = null;
            if (cmdletContext.Resources_S3Resource != null)
            {
                requestResources_resources_S3Resource = cmdletContext.Resources_S3Resource;
            }
            if (requestResources_resources_S3Resource != null)
            {
                request.Resources.S3Resources = requestResources_resources_S3Resource;
                requestResourcesIsNull = false;
            }
             // determine if request.Resources should be set to null
            if (requestResourcesIsNull)
            {
                request.Resources = null;
            }
            if (cmdletContext.RoleARN != null)
            {
                request.RoleARN = cmdletContext.RoleARN;
            }
            if (cmdletContext.ShippingOption != null)
            {
                request.ShippingOption = cmdletContext.ShippingOption;
            }
            if (cmdletContext.SnowballCapacityPreference != null)
            {
                request.SnowballCapacityPreference = cmdletContext.SnowballCapacityPreference;
            }
            if (cmdletContext.SnowballType != null)
            {
                request.SnowballType = cmdletContext.SnowballType;
            }
            
             // populate TaxDocuments
            var requestTaxDocumentsIsNull = true;
            request.TaxDocuments = new Amazon.Snowball.Model.TaxDocuments();
            Amazon.Snowball.Model.INDTaxDocuments requestTaxDocuments_taxDocuments_IND = null;
            
             // populate IND
            var requestTaxDocuments_taxDocuments_INDIsNull = true;
            requestTaxDocuments_taxDocuments_IND = new Amazon.Snowball.Model.INDTaxDocuments();
            System.String requestTaxDocuments_taxDocuments_IND_iND_GSTIN = null;
            if (cmdletContext.IND_GSTIN != null)
            {
                requestTaxDocuments_taxDocuments_IND_iND_GSTIN = cmdletContext.IND_GSTIN;
            }
            if (requestTaxDocuments_taxDocuments_IND_iND_GSTIN != null)
            {
                requestTaxDocuments_taxDocuments_IND.GSTIN = requestTaxDocuments_taxDocuments_IND_iND_GSTIN;
                requestTaxDocuments_taxDocuments_INDIsNull = false;
            }
             // determine if requestTaxDocuments_taxDocuments_IND should be set to null
            if (requestTaxDocuments_taxDocuments_INDIsNull)
            {
                requestTaxDocuments_taxDocuments_IND = null;
            }
            if (requestTaxDocuments_taxDocuments_IND != null)
            {
                request.TaxDocuments.IND = requestTaxDocuments_taxDocuments_IND;
                requestTaxDocumentsIsNull = false;
            }
             // determine if request.TaxDocuments should be set to null
            if (requestTaxDocumentsIsNull)
            {
                request.TaxDocuments = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Snowball.Model.CreateJobResponse CallAWSServiceOperation(IAmazonSnowball client, Amazon.Snowball.Model.CreateJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Import/Export Snowball", "CreateJob");
            try
            {
                #if DESKTOP
                return client.CreateJob(request);
                #elif CORECLR
                return client.CreateJobAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String AddressId { get; set; }
            public System.String ClusterId { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? WirelessConnection_IsWifiEnabled { get; set; }
            public System.String ForwardingAddressId { get; set; }
            public Amazon.Snowball.ImpactLevel ImpactLevel { get; set; }
            public Amazon.Snowball.JobType JobType { get; set; }
            public System.String KmsKeyARN { get; set; }
            public System.String LongTermPricingId { get; set; }
            public System.String Notification_DevicePickupSnsTopicARN { get; set; }
            public List<System.String> Notification_JobStatesToNotify { get; set; }
            public System.Boolean? Notification_NotifyAll { get; set; }
            public System.String Notification_SnsTopicARN { get; set; }
            public System.String EKSOnDeviceService_EKSAnywhereVersion { get; set; }
            public System.String EKSOnDeviceService_KubernetesVersion { get; set; }
            public System.Int32? NFSOnDeviceService_StorageLimit { get; set; }
            public Amazon.Snowball.StorageUnit NFSOnDeviceService_StorageUnit { get; set; }
            public System.Int32? S3OnDeviceService_FaultTolerance { get; set; }
            public System.Int32? S3OnDeviceService_ServiceSize { get; set; }
            public System.Double? S3OnDeviceService_StorageLimit { get; set; }
            public Amazon.Snowball.StorageUnit S3OnDeviceService_StorageUnit { get; set; }
            public System.Int32? TGWOnDeviceService_StorageLimit { get; set; }
            public Amazon.Snowball.StorageUnit TGWOnDeviceService_StorageUnit { get; set; }
            public System.String PickupDetails_DevicePickupId { get; set; }
            public System.String PickupDetails_Email { get; set; }
            public System.DateTime? PickupDetails_IdentificationExpirationDate { get; set; }
            public System.String PickupDetails_IdentificationIssuingOrg { get; set; }
            public System.String PickupDetails_IdentificationNumber { get; set; }
            public System.String PickupDetails_Name { get; set; }
            public System.String PickupDetails_PhoneNumber { get; set; }
            public Amazon.Snowball.RemoteManagement RemoteManagement { get; set; }
            public List<Amazon.Snowball.Model.Ec2AmiResource> Resources_Ec2AmiResource { get; set; }
            public List<Amazon.Snowball.Model.LambdaResource> Resources_LambdaResource { get; set; }
            public List<Amazon.Snowball.Model.S3Resource> Resources_S3Resource { get; set; }
            public System.String RoleARN { get; set; }
            public Amazon.Snowball.ShippingOption ShippingOption { get; set; }
            public Amazon.Snowball.SnowballCapacity SnowballCapacityPreference { get; set; }
            public Amazon.Snowball.SnowballType SnowballType { get; set; }
            public System.String IND_GSTIN { get; set; }
            public System.Func<Amazon.Snowball.Model.CreateJobResponse, NewSNOWJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobId;
        }
        
    }
}
