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
using Amazon.Outposts;
using Amazon.Outposts.Model;

namespace Amazon.PowerShell.Cmdlets.OUTP
{
    /// <summary>
    /// Creates a site for an Outpost.
    /// </summary>
    [Cmdlet("New", "OUTPSite", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Outposts.Model.Site")]
    [AWSCmdlet("Calls the AWS Outposts CreateSite API operation.", Operation = new[] {"CreateSite"}, SelectReturnType = typeof(Amazon.Outposts.Model.CreateSiteResponse))]
    [AWSCmdletOutput("Amazon.Outposts.Model.Site or Amazon.Outposts.Model.CreateSiteResponse",
        "This cmdlet returns an Amazon.Outposts.Model.Site object.",
        "The service call response (type Amazon.Outposts.Model.CreateSiteResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewOUTPSiteCmdlet : AmazonOutpostsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OperatingAddress_AddressLine1
        /// <summary>
        /// <para>
        /// <para>The first line of the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperatingAddress_AddressLine1 { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_AddressLine1
        /// <summary>
        /// <para>
        /// <para>The first line of the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_AddressLine1 { get; set; }
        #endregion
        
        #region Parameter OperatingAddress_AddressLine2
        /// <summary>
        /// <para>
        /// <para>The second line of the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperatingAddress_AddressLine2 { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_AddressLine2
        /// <summary>
        /// <para>
        /// <para>The second line of the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_AddressLine2 { get; set; }
        #endregion
        
        #region Parameter OperatingAddress_AddressLine3
        /// <summary>
        /// <para>
        /// <para>The third line of the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperatingAddress_AddressLine3 { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_AddressLine3
        /// <summary>
        /// <para>
        /// <para>The third line of the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_AddressLine3 { get; set; }
        #endregion
        
        #region Parameter OperatingAddress_City
        /// <summary>
        /// <para>
        /// <para>The city for the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperatingAddress_City { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_City
        /// <summary>
        /// <para>
        /// <para>The city for the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_City { get; set; }
        #endregion
        
        #region Parameter OperatingAddress_ContactName
        /// <summary>
        /// <para>
        /// <para>The name of the contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperatingAddress_ContactName { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_ContactName
        /// <summary>
        /// <para>
        /// <para>The name of the contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_ContactName { get; set; }
        #endregion
        
        #region Parameter OperatingAddress_ContactPhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number of the contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperatingAddress_ContactPhoneNumber { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_ContactPhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number of the contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_ContactPhoneNumber { get; set; }
        #endregion
        
        #region Parameter OperatingAddress_CountryCode
        /// <summary>
        /// <para>
        /// <para>The ISO-3166 two-letter country code for the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperatingAddress_CountryCode { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_CountryCode
        /// <summary>
        /// <para>
        /// <para>The ISO-3166 two-letter country code for the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_CountryCode { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter OperatingAddress_DistrictOrCounty
        /// <summary>
        /// <para>
        /// <para>The district or county for the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperatingAddress_DistrictOrCounty { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_DistrictOrCounty
        /// <summary>
        /// <para>
        /// <para>The district or county for the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_DistrictOrCounty { get; set; }
        #endregion
        
        #region Parameter RackPhysicalProperties_FiberOpticCableType
        /// <summary>
        /// <para>
        /// <para>The type of fiber used to attach the Outpost to the network. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Outposts.FiberOpticCableType")]
        public Amazon.Outposts.FiberOpticCableType RackPhysicalProperties_FiberOpticCableType { get; set; }
        #endregion
        
        #region Parameter RackPhysicalProperties_MaximumSupportedWeightLb
        /// <summary>
        /// <para>
        /// <para>The maximum rack weight that this site can support. <c>NO_LIMIT</c> is over 2000 lbs
        /// (907 kg). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RackPhysicalProperties_MaximumSupportedWeightLbs")]
        [AWSConstantClassSource("Amazon.Outposts.MaximumSupportedWeightLbs")]
        public Amazon.Outposts.MaximumSupportedWeightLbs RackPhysicalProperties_MaximumSupportedWeightLb { get; set; }
        #endregion
        
        #region Parameter OperatingAddress_Municipality
        /// <summary>
        /// <para>
        /// <para>The municipality for the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperatingAddress_Municipality { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_Municipality
        /// <summary>
        /// <para>
        /// <para>The municipality for the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_Municipality { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Note
        /// <summary>
        /// <para>
        /// <para>Additional information that you provide about site access requirements, electrician
        /// scheduling, personal protective equipment, or regulation of equipment materials that
        /// could affect your installation process. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Notes")]
        public System.String Note { get; set; }
        #endregion
        
        #region Parameter RackPhysicalProperties_OpticalStandard
        /// <summary>
        /// <para>
        /// <para>The type of optical standard used to attach the Outpost to the network. This field
        /// is dependent on uplink speed, fiber type, and distance to the upstream device. For
        /// more information about networking requirements for racks, see <a href="https://docs.aws.amazon.com/outposts/latest/userguide/outposts-requirements.html#facility-networking">Network</a>
        /// in the Amazon Web Services Outposts User Guide. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Outposts.OpticalStandard")]
        public Amazon.Outposts.OpticalStandard RackPhysicalProperties_OpticalStandard { get; set; }
        #endregion
        
        #region Parameter OperatingAddress_PostalCode
        /// <summary>
        /// <para>
        /// <para>The postal code for the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperatingAddress_PostalCode { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_PostalCode
        /// <summary>
        /// <para>
        /// <para>The postal code for the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_PostalCode { get; set; }
        #endregion
        
        #region Parameter RackPhysicalProperties_PowerConnector
        /// <summary>
        /// <para>
        /// <para>The power connector for the hardware. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Outposts.PowerConnector")]
        public Amazon.Outposts.PowerConnector RackPhysicalProperties_PowerConnector { get; set; }
        #endregion
        
        #region Parameter RackPhysicalProperties_PowerDrawKva
        /// <summary>
        /// <para>
        /// <para>The power draw available at the hardware placement position for the rack. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Outposts.PowerDrawKva")]
        public Amazon.Outposts.PowerDrawKva RackPhysicalProperties_PowerDrawKva { get; set; }
        #endregion
        
        #region Parameter RackPhysicalProperties_PowerFeedDrop
        /// <summary>
        /// <para>
        /// <para>The position of the power feed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Outposts.PowerFeedDrop")]
        public Amazon.Outposts.PowerFeedDrop RackPhysicalProperties_PowerFeedDrop { get; set; }
        #endregion
        
        #region Parameter RackPhysicalProperties_PowerPhase
        /// <summary>
        /// <para>
        /// <para>The power option that you can provide for hardware.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Outposts.PowerPhase")]
        public Amazon.Outposts.PowerPhase RackPhysicalProperties_PowerPhase { get; set; }
        #endregion
        
        #region Parameter OperatingAddress_StateOrRegion
        /// <summary>
        /// <para>
        /// <para>The state for the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperatingAddress_StateOrRegion { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_StateOrRegion
        /// <summary>
        /// <para>
        /// <para>The state for the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_StateOrRegion { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> The tags to apply to a site. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter RackPhysicalProperties_UplinkCount
        /// <summary>
        /// <para>
        /// <para>The number of uplinks each Outpost network device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Outposts.UplinkCount")]
        public Amazon.Outposts.UplinkCount RackPhysicalProperties_UplinkCount { get; set; }
        #endregion
        
        #region Parameter RackPhysicalProperties_UplinkGbp
        /// <summary>
        /// <para>
        /// <para>The uplink speed the rack supports for the connection to the Region. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RackPhysicalProperties_UplinkGbps")]
        [AWSConstantClassSource("Amazon.Outposts.UplinkGbps")]
        public Amazon.Outposts.UplinkGbps RackPhysicalProperties_UplinkGbp { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Site'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Outposts.Model.CreateSiteResponse).
        /// Specifying the name of a property of type Amazon.Outposts.Model.CreateSiteResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Site";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OUTPSite (CreateSite)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Outposts.Model.CreateSiteResponse, NewOUTPSiteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Note = this.Note;
            context.OperatingAddress_AddressLine1 = this.OperatingAddress_AddressLine1;
            context.OperatingAddress_AddressLine2 = this.OperatingAddress_AddressLine2;
            context.OperatingAddress_AddressLine3 = this.OperatingAddress_AddressLine3;
            context.OperatingAddress_City = this.OperatingAddress_City;
            context.OperatingAddress_ContactName = this.OperatingAddress_ContactName;
            context.OperatingAddress_ContactPhoneNumber = this.OperatingAddress_ContactPhoneNumber;
            context.OperatingAddress_CountryCode = this.OperatingAddress_CountryCode;
            context.OperatingAddress_DistrictOrCounty = this.OperatingAddress_DistrictOrCounty;
            context.OperatingAddress_Municipality = this.OperatingAddress_Municipality;
            context.OperatingAddress_PostalCode = this.OperatingAddress_PostalCode;
            context.OperatingAddress_StateOrRegion = this.OperatingAddress_StateOrRegion;
            context.RackPhysicalProperties_FiberOpticCableType = this.RackPhysicalProperties_FiberOpticCableType;
            context.RackPhysicalProperties_MaximumSupportedWeightLb = this.RackPhysicalProperties_MaximumSupportedWeightLb;
            context.RackPhysicalProperties_OpticalStandard = this.RackPhysicalProperties_OpticalStandard;
            context.RackPhysicalProperties_PowerConnector = this.RackPhysicalProperties_PowerConnector;
            context.RackPhysicalProperties_PowerDrawKva = this.RackPhysicalProperties_PowerDrawKva;
            context.RackPhysicalProperties_PowerFeedDrop = this.RackPhysicalProperties_PowerFeedDrop;
            context.RackPhysicalProperties_PowerPhase = this.RackPhysicalProperties_PowerPhase;
            context.RackPhysicalProperties_UplinkCount = this.RackPhysicalProperties_UplinkCount;
            context.RackPhysicalProperties_UplinkGbp = this.RackPhysicalProperties_UplinkGbp;
            context.ShippingAddress_AddressLine1 = this.ShippingAddress_AddressLine1;
            context.ShippingAddress_AddressLine2 = this.ShippingAddress_AddressLine2;
            context.ShippingAddress_AddressLine3 = this.ShippingAddress_AddressLine3;
            context.ShippingAddress_City = this.ShippingAddress_City;
            context.ShippingAddress_ContactName = this.ShippingAddress_ContactName;
            context.ShippingAddress_ContactPhoneNumber = this.ShippingAddress_ContactPhoneNumber;
            context.ShippingAddress_CountryCode = this.ShippingAddress_CountryCode;
            context.ShippingAddress_DistrictOrCounty = this.ShippingAddress_DistrictOrCounty;
            context.ShippingAddress_Municipality = this.ShippingAddress_Municipality;
            context.ShippingAddress_PostalCode = this.ShippingAddress_PostalCode;
            context.ShippingAddress_StateOrRegion = this.ShippingAddress_StateOrRegion;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.Outposts.Model.CreateSiteRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Note != null)
            {
                request.Notes = cmdletContext.Note;
            }
            
             // populate OperatingAddress
            var requestOperatingAddressIsNull = true;
            request.OperatingAddress = new Amazon.Outposts.Model.Address();
            System.String requestOperatingAddress_operatingAddress_AddressLine1 = null;
            if (cmdletContext.OperatingAddress_AddressLine1 != null)
            {
                requestOperatingAddress_operatingAddress_AddressLine1 = cmdletContext.OperatingAddress_AddressLine1;
            }
            if (requestOperatingAddress_operatingAddress_AddressLine1 != null)
            {
                request.OperatingAddress.AddressLine1 = requestOperatingAddress_operatingAddress_AddressLine1;
                requestOperatingAddressIsNull = false;
            }
            System.String requestOperatingAddress_operatingAddress_AddressLine2 = null;
            if (cmdletContext.OperatingAddress_AddressLine2 != null)
            {
                requestOperatingAddress_operatingAddress_AddressLine2 = cmdletContext.OperatingAddress_AddressLine2;
            }
            if (requestOperatingAddress_operatingAddress_AddressLine2 != null)
            {
                request.OperatingAddress.AddressLine2 = requestOperatingAddress_operatingAddress_AddressLine2;
                requestOperatingAddressIsNull = false;
            }
            System.String requestOperatingAddress_operatingAddress_AddressLine3 = null;
            if (cmdletContext.OperatingAddress_AddressLine3 != null)
            {
                requestOperatingAddress_operatingAddress_AddressLine3 = cmdletContext.OperatingAddress_AddressLine3;
            }
            if (requestOperatingAddress_operatingAddress_AddressLine3 != null)
            {
                request.OperatingAddress.AddressLine3 = requestOperatingAddress_operatingAddress_AddressLine3;
                requestOperatingAddressIsNull = false;
            }
            System.String requestOperatingAddress_operatingAddress_City = null;
            if (cmdletContext.OperatingAddress_City != null)
            {
                requestOperatingAddress_operatingAddress_City = cmdletContext.OperatingAddress_City;
            }
            if (requestOperatingAddress_operatingAddress_City != null)
            {
                request.OperatingAddress.City = requestOperatingAddress_operatingAddress_City;
                requestOperatingAddressIsNull = false;
            }
            System.String requestOperatingAddress_operatingAddress_ContactName = null;
            if (cmdletContext.OperatingAddress_ContactName != null)
            {
                requestOperatingAddress_operatingAddress_ContactName = cmdletContext.OperatingAddress_ContactName;
            }
            if (requestOperatingAddress_operatingAddress_ContactName != null)
            {
                request.OperatingAddress.ContactName = requestOperatingAddress_operatingAddress_ContactName;
                requestOperatingAddressIsNull = false;
            }
            System.String requestOperatingAddress_operatingAddress_ContactPhoneNumber = null;
            if (cmdletContext.OperatingAddress_ContactPhoneNumber != null)
            {
                requestOperatingAddress_operatingAddress_ContactPhoneNumber = cmdletContext.OperatingAddress_ContactPhoneNumber;
            }
            if (requestOperatingAddress_operatingAddress_ContactPhoneNumber != null)
            {
                request.OperatingAddress.ContactPhoneNumber = requestOperatingAddress_operatingAddress_ContactPhoneNumber;
                requestOperatingAddressIsNull = false;
            }
            System.String requestOperatingAddress_operatingAddress_CountryCode = null;
            if (cmdletContext.OperatingAddress_CountryCode != null)
            {
                requestOperatingAddress_operatingAddress_CountryCode = cmdletContext.OperatingAddress_CountryCode;
            }
            if (requestOperatingAddress_operatingAddress_CountryCode != null)
            {
                request.OperatingAddress.CountryCode = requestOperatingAddress_operatingAddress_CountryCode;
                requestOperatingAddressIsNull = false;
            }
            System.String requestOperatingAddress_operatingAddress_DistrictOrCounty = null;
            if (cmdletContext.OperatingAddress_DistrictOrCounty != null)
            {
                requestOperatingAddress_operatingAddress_DistrictOrCounty = cmdletContext.OperatingAddress_DistrictOrCounty;
            }
            if (requestOperatingAddress_operatingAddress_DistrictOrCounty != null)
            {
                request.OperatingAddress.DistrictOrCounty = requestOperatingAddress_operatingAddress_DistrictOrCounty;
                requestOperatingAddressIsNull = false;
            }
            System.String requestOperatingAddress_operatingAddress_Municipality = null;
            if (cmdletContext.OperatingAddress_Municipality != null)
            {
                requestOperatingAddress_operatingAddress_Municipality = cmdletContext.OperatingAddress_Municipality;
            }
            if (requestOperatingAddress_operatingAddress_Municipality != null)
            {
                request.OperatingAddress.Municipality = requestOperatingAddress_operatingAddress_Municipality;
                requestOperatingAddressIsNull = false;
            }
            System.String requestOperatingAddress_operatingAddress_PostalCode = null;
            if (cmdletContext.OperatingAddress_PostalCode != null)
            {
                requestOperatingAddress_operatingAddress_PostalCode = cmdletContext.OperatingAddress_PostalCode;
            }
            if (requestOperatingAddress_operatingAddress_PostalCode != null)
            {
                request.OperatingAddress.PostalCode = requestOperatingAddress_operatingAddress_PostalCode;
                requestOperatingAddressIsNull = false;
            }
            System.String requestOperatingAddress_operatingAddress_StateOrRegion = null;
            if (cmdletContext.OperatingAddress_StateOrRegion != null)
            {
                requestOperatingAddress_operatingAddress_StateOrRegion = cmdletContext.OperatingAddress_StateOrRegion;
            }
            if (requestOperatingAddress_operatingAddress_StateOrRegion != null)
            {
                request.OperatingAddress.StateOrRegion = requestOperatingAddress_operatingAddress_StateOrRegion;
                requestOperatingAddressIsNull = false;
            }
             // determine if request.OperatingAddress should be set to null
            if (requestOperatingAddressIsNull)
            {
                request.OperatingAddress = null;
            }
            
             // populate RackPhysicalProperties
            var requestRackPhysicalPropertiesIsNull = true;
            request.RackPhysicalProperties = new Amazon.Outposts.Model.RackPhysicalProperties();
            Amazon.Outposts.FiberOpticCableType requestRackPhysicalProperties_rackPhysicalProperties_FiberOpticCableType = null;
            if (cmdletContext.RackPhysicalProperties_FiberOpticCableType != null)
            {
                requestRackPhysicalProperties_rackPhysicalProperties_FiberOpticCableType = cmdletContext.RackPhysicalProperties_FiberOpticCableType;
            }
            if (requestRackPhysicalProperties_rackPhysicalProperties_FiberOpticCableType != null)
            {
                request.RackPhysicalProperties.FiberOpticCableType = requestRackPhysicalProperties_rackPhysicalProperties_FiberOpticCableType;
                requestRackPhysicalPropertiesIsNull = false;
            }
            Amazon.Outposts.MaximumSupportedWeightLbs requestRackPhysicalProperties_rackPhysicalProperties_MaximumSupportedWeightLb = null;
            if (cmdletContext.RackPhysicalProperties_MaximumSupportedWeightLb != null)
            {
                requestRackPhysicalProperties_rackPhysicalProperties_MaximumSupportedWeightLb = cmdletContext.RackPhysicalProperties_MaximumSupportedWeightLb;
            }
            if (requestRackPhysicalProperties_rackPhysicalProperties_MaximumSupportedWeightLb != null)
            {
                request.RackPhysicalProperties.MaximumSupportedWeightLbs = requestRackPhysicalProperties_rackPhysicalProperties_MaximumSupportedWeightLb;
                requestRackPhysicalPropertiesIsNull = false;
            }
            Amazon.Outposts.OpticalStandard requestRackPhysicalProperties_rackPhysicalProperties_OpticalStandard = null;
            if (cmdletContext.RackPhysicalProperties_OpticalStandard != null)
            {
                requestRackPhysicalProperties_rackPhysicalProperties_OpticalStandard = cmdletContext.RackPhysicalProperties_OpticalStandard;
            }
            if (requestRackPhysicalProperties_rackPhysicalProperties_OpticalStandard != null)
            {
                request.RackPhysicalProperties.OpticalStandard = requestRackPhysicalProperties_rackPhysicalProperties_OpticalStandard;
                requestRackPhysicalPropertiesIsNull = false;
            }
            Amazon.Outposts.PowerConnector requestRackPhysicalProperties_rackPhysicalProperties_PowerConnector = null;
            if (cmdletContext.RackPhysicalProperties_PowerConnector != null)
            {
                requestRackPhysicalProperties_rackPhysicalProperties_PowerConnector = cmdletContext.RackPhysicalProperties_PowerConnector;
            }
            if (requestRackPhysicalProperties_rackPhysicalProperties_PowerConnector != null)
            {
                request.RackPhysicalProperties.PowerConnector = requestRackPhysicalProperties_rackPhysicalProperties_PowerConnector;
                requestRackPhysicalPropertiesIsNull = false;
            }
            Amazon.Outposts.PowerDrawKva requestRackPhysicalProperties_rackPhysicalProperties_PowerDrawKva = null;
            if (cmdletContext.RackPhysicalProperties_PowerDrawKva != null)
            {
                requestRackPhysicalProperties_rackPhysicalProperties_PowerDrawKva = cmdletContext.RackPhysicalProperties_PowerDrawKva;
            }
            if (requestRackPhysicalProperties_rackPhysicalProperties_PowerDrawKva != null)
            {
                request.RackPhysicalProperties.PowerDrawKva = requestRackPhysicalProperties_rackPhysicalProperties_PowerDrawKva;
                requestRackPhysicalPropertiesIsNull = false;
            }
            Amazon.Outposts.PowerFeedDrop requestRackPhysicalProperties_rackPhysicalProperties_PowerFeedDrop = null;
            if (cmdletContext.RackPhysicalProperties_PowerFeedDrop != null)
            {
                requestRackPhysicalProperties_rackPhysicalProperties_PowerFeedDrop = cmdletContext.RackPhysicalProperties_PowerFeedDrop;
            }
            if (requestRackPhysicalProperties_rackPhysicalProperties_PowerFeedDrop != null)
            {
                request.RackPhysicalProperties.PowerFeedDrop = requestRackPhysicalProperties_rackPhysicalProperties_PowerFeedDrop;
                requestRackPhysicalPropertiesIsNull = false;
            }
            Amazon.Outposts.PowerPhase requestRackPhysicalProperties_rackPhysicalProperties_PowerPhase = null;
            if (cmdletContext.RackPhysicalProperties_PowerPhase != null)
            {
                requestRackPhysicalProperties_rackPhysicalProperties_PowerPhase = cmdletContext.RackPhysicalProperties_PowerPhase;
            }
            if (requestRackPhysicalProperties_rackPhysicalProperties_PowerPhase != null)
            {
                request.RackPhysicalProperties.PowerPhase = requestRackPhysicalProperties_rackPhysicalProperties_PowerPhase;
                requestRackPhysicalPropertiesIsNull = false;
            }
            Amazon.Outposts.UplinkCount requestRackPhysicalProperties_rackPhysicalProperties_UplinkCount = null;
            if (cmdletContext.RackPhysicalProperties_UplinkCount != null)
            {
                requestRackPhysicalProperties_rackPhysicalProperties_UplinkCount = cmdletContext.RackPhysicalProperties_UplinkCount;
            }
            if (requestRackPhysicalProperties_rackPhysicalProperties_UplinkCount != null)
            {
                request.RackPhysicalProperties.UplinkCount = requestRackPhysicalProperties_rackPhysicalProperties_UplinkCount;
                requestRackPhysicalPropertiesIsNull = false;
            }
            Amazon.Outposts.UplinkGbps requestRackPhysicalProperties_rackPhysicalProperties_UplinkGbp = null;
            if (cmdletContext.RackPhysicalProperties_UplinkGbp != null)
            {
                requestRackPhysicalProperties_rackPhysicalProperties_UplinkGbp = cmdletContext.RackPhysicalProperties_UplinkGbp;
            }
            if (requestRackPhysicalProperties_rackPhysicalProperties_UplinkGbp != null)
            {
                request.RackPhysicalProperties.UplinkGbps = requestRackPhysicalProperties_rackPhysicalProperties_UplinkGbp;
                requestRackPhysicalPropertiesIsNull = false;
            }
             // determine if request.RackPhysicalProperties should be set to null
            if (requestRackPhysicalPropertiesIsNull)
            {
                request.RackPhysicalProperties = null;
            }
            
             // populate ShippingAddress
            var requestShippingAddressIsNull = true;
            request.ShippingAddress = new Amazon.Outposts.Model.Address();
            System.String requestShippingAddress_shippingAddress_AddressLine1 = null;
            if (cmdletContext.ShippingAddress_AddressLine1 != null)
            {
                requestShippingAddress_shippingAddress_AddressLine1 = cmdletContext.ShippingAddress_AddressLine1;
            }
            if (requestShippingAddress_shippingAddress_AddressLine1 != null)
            {
                request.ShippingAddress.AddressLine1 = requestShippingAddress_shippingAddress_AddressLine1;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_AddressLine2 = null;
            if (cmdletContext.ShippingAddress_AddressLine2 != null)
            {
                requestShippingAddress_shippingAddress_AddressLine2 = cmdletContext.ShippingAddress_AddressLine2;
            }
            if (requestShippingAddress_shippingAddress_AddressLine2 != null)
            {
                request.ShippingAddress.AddressLine2 = requestShippingAddress_shippingAddress_AddressLine2;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_AddressLine3 = null;
            if (cmdletContext.ShippingAddress_AddressLine3 != null)
            {
                requestShippingAddress_shippingAddress_AddressLine3 = cmdletContext.ShippingAddress_AddressLine3;
            }
            if (requestShippingAddress_shippingAddress_AddressLine3 != null)
            {
                request.ShippingAddress.AddressLine3 = requestShippingAddress_shippingAddress_AddressLine3;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_City = null;
            if (cmdletContext.ShippingAddress_City != null)
            {
                requestShippingAddress_shippingAddress_City = cmdletContext.ShippingAddress_City;
            }
            if (requestShippingAddress_shippingAddress_City != null)
            {
                request.ShippingAddress.City = requestShippingAddress_shippingAddress_City;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_ContactName = null;
            if (cmdletContext.ShippingAddress_ContactName != null)
            {
                requestShippingAddress_shippingAddress_ContactName = cmdletContext.ShippingAddress_ContactName;
            }
            if (requestShippingAddress_shippingAddress_ContactName != null)
            {
                request.ShippingAddress.ContactName = requestShippingAddress_shippingAddress_ContactName;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_ContactPhoneNumber = null;
            if (cmdletContext.ShippingAddress_ContactPhoneNumber != null)
            {
                requestShippingAddress_shippingAddress_ContactPhoneNumber = cmdletContext.ShippingAddress_ContactPhoneNumber;
            }
            if (requestShippingAddress_shippingAddress_ContactPhoneNumber != null)
            {
                request.ShippingAddress.ContactPhoneNumber = requestShippingAddress_shippingAddress_ContactPhoneNumber;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_CountryCode = null;
            if (cmdletContext.ShippingAddress_CountryCode != null)
            {
                requestShippingAddress_shippingAddress_CountryCode = cmdletContext.ShippingAddress_CountryCode;
            }
            if (requestShippingAddress_shippingAddress_CountryCode != null)
            {
                request.ShippingAddress.CountryCode = requestShippingAddress_shippingAddress_CountryCode;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_DistrictOrCounty = null;
            if (cmdletContext.ShippingAddress_DistrictOrCounty != null)
            {
                requestShippingAddress_shippingAddress_DistrictOrCounty = cmdletContext.ShippingAddress_DistrictOrCounty;
            }
            if (requestShippingAddress_shippingAddress_DistrictOrCounty != null)
            {
                request.ShippingAddress.DistrictOrCounty = requestShippingAddress_shippingAddress_DistrictOrCounty;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_Municipality = null;
            if (cmdletContext.ShippingAddress_Municipality != null)
            {
                requestShippingAddress_shippingAddress_Municipality = cmdletContext.ShippingAddress_Municipality;
            }
            if (requestShippingAddress_shippingAddress_Municipality != null)
            {
                request.ShippingAddress.Municipality = requestShippingAddress_shippingAddress_Municipality;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_PostalCode = null;
            if (cmdletContext.ShippingAddress_PostalCode != null)
            {
                requestShippingAddress_shippingAddress_PostalCode = cmdletContext.ShippingAddress_PostalCode;
            }
            if (requestShippingAddress_shippingAddress_PostalCode != null)
            {
                request.ShippingAddress.PostalCode = requestShippingAddress_shippingAddress_PostalCode;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_StateOrRegion = null;
            if (cmdletContext.ShippingAddress_StateOrRegion != null)
            {
                requestShippingAddress_shippingAddress_StateOrRegion = cmdletContext.ShippingAddress_StateOrRegion;
            }
            if (requestShippingAddress_shippingAddress_StateOrRegion != null)
            {
                request.ShippingAddress.StateOrRegion = requestShippingAddress_shippingAddress_StateOrRegion;
                requestShippingAddressIsNull = false;
            }
             // determine if request.ShippingAddress should be set to null
            if (requestShippingAddressIsNull)
            {
                request.ShippingAddress = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Outposts.Model.CreateSiteResponse CallAWSServiceOperation(IAmazonOutposts client, Amazon.Outposts.Model.CreateSiteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Outposts", "CreateSite");
            try
            {
                #if DESKTOP
                return client.CreateSite(request);
                #elif CORECLR
                return client.CreateSiteAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String Note { get; set; }
            public System.String OperatingAddress_AddressLine1 { get; set; }
            public System.String OperatingAddress_AddressLine2 { get; set; }
            public System.String OperatingAddress_AddressLine3 { get; set; }
            public System.String OperatingAddress_City { get; set; }
            public System.String OperatingAddress_ContactName { get; set; }
            public System.String OperatingAddress_ContactPhoneNumber { get; set; }
            public System.String OperatingAddress_CountryCode { get; set; }
            public System.String OperatingAddress_DistrictOrCounty { get; set; }
            public System.String OperatingAddress_Municipality { get; set; }
            public System.String OperatingAddress_PostalCode { get; set; }
            public System.String OperatingAddress_StateOrRegion { get; set; }
            public Amazon.Outposts.FiberOpticCableType RackPhysicalProperties_FiberOpticCableType { get; set; }
            public Amazon.Outposts.MaximumSupportedWeightLbs RackPhysicalProperties_MaximumSupportedWeightLb { get; set; }
            public Amazon.Outposts.OpticalStandard RackPhysicalProperties_OpticalStandard { get; set; }
            public Amazon.Outposts.PowerConnector RackPhysicalProperties_PowerConnector { get; set; }
            public Amazon.Outposts.PowerDrawKva RackPhysicalProperties_PowerDrawKva { get; set; }
            public Amazon.Outposts.PowerFeedDrop RackPhysicalProperties_PowerFeedDrop { get; set; }
            public Amazon.Outposts.PowerPhase RackPhysicalProperties_PowerPhase { get; set; }
            public Amazon.Outposts.UplinkCount RackPhysicalProperties_UplinkCount { get; set; }
            public Amazon.Outposts.UplinkGbps RackPhysicalProperties_UplinkGbp { get; set; }
            public System.String ShippingAddress_AddressLine1 { get; set; }
            public System.String ShippingAddress_AddressLine2 { get; set; }
            public System.String ShippingAddress_AddressLine3 { get; set; }
            public System.String ShippingAddress_City { get; set; }
            public System.String ShippingAddress_ContactName { get; set; }
            public System.String ShippingAddress_ContactPhoneNumber { get; set; }
            public System.String ShippingAddress_CountryCode { get; set; }
            public System.String ShippingAddress_DistrictOrCounty { get; set; }
            public System.String ShippingAddress_Municipality { get; set; }
            public System.String ShippingAddress_PostalCode { get; set; }
            public System.String ShippingAddress_StateOrRegion { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Outposts.Model.CreateSiteResponse, NewOUTPSiteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Site;
        }
        
    }
}
