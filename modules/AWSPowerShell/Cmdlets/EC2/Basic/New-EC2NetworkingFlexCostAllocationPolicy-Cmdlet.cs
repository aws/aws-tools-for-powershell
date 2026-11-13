/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a flex cost allocation policy for Networking Flexible Cost Allocation (FCA),
    /// a feature of Amazon Virtual Private Cloud (Amazon VPC). The policy allocates the charges
    /// of a shared networking resource at the reporting granularity that you specify. You
    /// can create a policy for one of the following resource types: NAT gateways, Amazon
    /// VPC peering connections, or EC2 instances. Policies can allocate data transfer charges
    /// for all three types, and data processing charges for NAT gateways.
    /// 
    ///  
    /// <para>
    /// You can have up to 100 policies per account in each Amazon Web Services Region, plus
    /// one additional policy per network resource type created by a declarative policy, for
    /// a maximum of 103 policies in an Amazon Web Services Region.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2NetworkingFlexCostAllocationPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CreateNetworkingFlexCostAllocationPolicyResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud CreateNetworkingFlexCostAllocationPolicy API operation.", Operation = new[] {"CreateNetworkingFlexCostAllocationPolicy"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateNetworkingFlexCostAllocationPolicyResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.CreateNetworkingFlexCostAllocationPolicyResponse",
        "This cmdlet returns an Amazon.EC2.Model.CreateNetworkingFlexCostAllocationPolicyResponse object containing multiple properties."
    )]
    public partial class NewEC2NetworkingFlexCostAllocationPolicyCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the policy. The description can be up to 1024 characters long.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InstanceFcaPolicyDocument_Dimension
        /// <summary>
        /// <para>
        /// <para>The cost dimensions to report. This parameter is required. The only valid value is
        /// <c>data-transfer</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceFcaPolicyDocument_Dimensions")]
        public System.String[] InstanceFcaPolicyDocument_Dimension { get; set; }
        #endregion
        
        #region Parameter NatFcaPolicyDocument_Dimension
        /// <summary>
        /// <para>
        /// <para>The cost dimensions to report. This parameter is required. Valid values are <c>data-transfer</c>
        /// and <c>data-processing</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NatFcaPolicyDocument_Dimensions")]
        public System.String[] NatFcaPolicyDocument_Dimension { get; set; }
        #endregion
        
        #region Parameter PcxFcaPolicyDocument_Dimension
        /// <summary>
        /// <para>
        /// <para>The cost dimensions to report. This parameter is required. The only valid value is
        /// <c>data-transfer</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PcxFcaPolicyDocument_Dimensions")]
        public System.String[] PcxFcaPolicyDocument_Dimension { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter NetworkResourceType
        /// <summary>
        /// <para>
        /// <para>The type of network resource that the policy applies to. This parameter is required.
        /// Valid values are <c>natgw</c> (NAT gateway), <c>pcx</c> (Amazon VPC peering connection),
        /// and <c>ec2</c> (EC2 instance).</para><para>Specify the policy document that matches the resource type: <c>NatFcaPolicyDocument</c>
        /// for <c>natgw</c>, <c>InstanceFcaPolicyDocument</c> for <c>ec2</c>, or <c>PcxFcaPolicyDocument</c>
        /// for <c>pcx</c>. Don't specify a policy document for a different resource type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.FlexCostAllocationNetworkResourceType")]
        public Amazon.EC2.FlexCostAllocationNetworkResourceType NetworkResourceType { get; set; }
        #endregion
        
        #region Parameter InstanceFcaPolicyDocument_CidrRangeSpecifications_Prefix
        /// <summary>
        /// <para>
        /// <para>The CIDR range to label mappings. You can specify from 1 to 100 mappings. This parameter
        /// is required.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceFcaPolicyDocument_CidrRangeSpecifications_Prefixes")]
        public Amazon.EC2.Model.FlexCostAllocationCidrMapping[] InstanceFcaPolicyDocument_CidrRangeSpecifications_Prefix { get; set; }
        #endregion
        
        #region Parameter NatFcaPolicyDocument_CidrRangeSpecifications_Prefix
        /// <summary>
        /// <para>
        /// <para>The CIDR range to label mappings. You can specify from 1 to 100 mappings. This parameter
        /// is required.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NatFcaPolicyDocument_CidrRangeSpecifications_Prefixes")]
        public Amazon.EC2.Model.FlexCostAllocationCidrMapping[] NatFcaPolicyDocument_CidrRangeSpecifications_Prefix { get; set; }
        #endregion
        
        #region Parameter PcxFcaPolicyDocument_CidrRangeSpecifications_Prefix
        /// <summary>
        /// <para>
        /// <para>The CIDR range to label mappings. You can specify from 1 to 100 mappings. This parameter
        /// is required.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PcxFcaPolicyDocument_CidrRangeSpecifications_Prefixes")]
        public Amazon.EC2.Model.FlexCostAllocationCidrMapping[] PcxFcaPolicyDocument_CidrRangeSpecifications_Prefix { get; set; }
        #endregion
        
        #region Parameter InstanceFcaPolicyDocument_CidrRangeSpecifications_PrefixesType
        /// <summary>
        /// <para>
        /// <para>The type of prefixes to use. This parameter is required. Valid values are <c>source-prefixes</c>
        /// and <c>destination-prefixes</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceFcaPolicyDocument_CidrRangeSpecifications_PrefixesType { get; set; }
        #endregion
        
        #region Parameter NatFcaPolicyDocument_CidrRangeSpecifications_PrefixesType
        /// <summary>
        /// <para>
        /// <para>The type of prefixes to use. This parameter is required. Valid values are <c>source-prefixes</c>
        /// and <c>destination-prefixes</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NatFcaPolicyDocument_CidrRangeSpecifications_PrefixesType { get; set; }
        #endregion
        
        #region Parameter PcxFcaPolicyDocument_CidrRangeSpecifications_PrefixesType
        /// <summary>
        /// <para>
        /// <para>The type of prefixes to use. This parameter is required. Valid values are <c>source-prefixes</c>
        /// and <c>destination-prefixes</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PcxFcaPolicyDocument_CidrRangeSpecifications_PrefixesType { get; set; }
        #endregion
        
        #region Parameter InstanceFcaPolicyDocument_ReportingGranularity
        /// <summary>
        /// <para>
        /// <para>The resource granularity level at which networking costs are allocated. This parameter
        /// is required. Specify exactly one value. Valid values are <c>eni</c>, <c>ec2</c>, <c>subnet</c>,
        /// <c>vpc</c>, <c>account</c>, and <c>cidr</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] InstanceFcaPolicyDocument_ReportingGranularity { get; set; }
        #endregion
        
        #region Parameter NatFcaPolicyDocument_ReportingGranularity
        /// <summary>
        /// <para>
        /// <para>The resource granularity level at which networking costs are allocated. This parameter
        /// is required. Specify exactly one value. Valid values are <c>eni</c>, <c>ec2</c>, <c>subnet</c>,
        /// <c>vpc</c>, <c>account</c>, and <c>cidr</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] NatFcaPolicyDocument_ReportingGranularity { get; set; }
        #endregion
        
        #region Parameter PcxFcaPolicyDocument_ReportingGranularity
        /// <summary>
        /// <para>
        /// <para>The resource granularity level at which networking costs are allocated. This parameter
        /// is required. Specify exactly one value. Valid values are <c>eni</c>, <c>ec2</c>, <c>subnet</c>,
        /// <c>vpc</c>, <c>account</c>, <c>peering-id</c>, and <c>cidr</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PcxFcaPolicyDocument_ReportingGranularity { get; set; }
        #endregion
        
        #region Parameter ShowBackEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether showback reporting is enabled for the policy.</para><para>Default: <c>true</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ShowBackEnabled { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the policy.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateNetworkingFlexCostAllocationPolicyResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateNetworkingFlexCostAllocationPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2NetworkingFlexCostAllocationPolicy (CreateNetworkingFlexCostAllocationPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateNetworkingFlexCostAllocationPolicyResponse, NewEC2NetworkingFlexCostAllocationPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DryRun = this.DryRun;
            if (this.InstanceFcaPolicyDocument_CidrRangeSpecifications_Prefix != null)
            {
                context.InstanceFcaPolicyDocument_CidrRangeSpecifications_Prefix = new List<Amazon.EC2.Model.FlexCostAllocationCidrMapping>(this.InstanceFcaPolicyDocument_CidrRangeSpecifications_Prefix);
            }
            context.InstanceFcaPolicyDocument_CidrRangeSpecifications_PrefixesType = this.InstanceFcaPolicyDocument_CidrRangeSpecifications_PrefixesType;
            if (this.InstanceFcaPolicyDocument_Dimension != null)
            {
                context.InstanceFcaPolicyDocument_Dimension = new List<System.String>(this.InstanceFcaPolicyDocument_Dimension);
            }
            if (this.InstanceFcaPolicyDocument_ReportingGranularity != null)
            {
                context.InstanceFcaPolicyDocument_ReportingGranularity = new List<System.String>(this.InstanceFcaPolicyDocument_ReportingGranularity);
            }
            if (this.NatFcaPolicyDocument_CidrRangeSpecifications_Prefix != null)
            {
                context.NatFcaPolicyDocument_CidrRangeSpecifications_Prefix = new List<Amazon.EC2.Model.FlexCostAllocationCidrMapping>(this.NatFcaPolicyDocument_CidrRangeSpecifications_Prefix);
            }
            context.NatFcaPolicyDocument_CidrRangeSpecifications_PrefixesType = this.NatFcaPolicyDocument_CidrRangeSpecifications_PrefixesType;
            if (this.NatFcaPolicyDocument_Dimension != null)
            {
                context.NatFcaPolicyDocument_Dimension = new List<System.String>(this.NatFcaPolicyDocument_Dimension);
            }
            if (this.NatFcaPolicyDocument_ReportingGranularity != null)
            {
                context.NatFcaPolicyDocument_ReportingGranularity = new List<System.String>(this.NatFcaPolicyDocument_ReportingGranularity);
            }
            context.NetworkResourceType = this.NetworkResourceType;
            #if MODULAR
            if (this.NetworkResourceType == null && ParameterWasBound(nameof(this.NetworkResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PcxFcaPolicyDocument_CidrRangeSpecifications_Prefix != null)
            {
                context.PcxFcaPolicyDocument_CidrRangeSpecifications_Prefix = new List<Amazon.EC2.Model.FlexCostAllocationCidrMapping>(this.PcxFcaPolicyDocument_CidrRangeSpecifications_Prefix);
            }
            context.PcxFcaPolicyDocument_CidrRangeSpecifications_PrefixesType = this.PcxFcaPolicyDocument_CidrRangeSpecifications_PrefixesType;
            if (this.PcxFcaPolicyDocument_Dimension != null)
            {
                context.PcxFcaPolicyDocument_Dimension = new List<System.String>(this.PcxFcaPolicyDocument_Dimension);
            }
            if (this.PcxFcaPolicyDocument_ReportingGranularity != null)
            {
                context.PcxFcaPolicyDocument_ReportingGranularity = new List<System.String>(this.PcxFcaPolicyDocument_ReportingGranularity);
            }
            context.ShowBackEnabled = this.ShowBackEnabled;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
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
            var request = new Amazon.EC2.Model.CreateNetworkingFlexCostAllocationPolicyRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            
             // populate InstanceFcaPolicyDocument
            var requestInstanceFcaPolicyDocumentIsNull = true;
            request.InstanceFcaPolicyDocument = new Amazon.EC2.Model.InstanceFlexCostAllocationPolicyDocument();
            List<System.String> requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_Dimension = null;
            if (cmdletContext.InstanceFcaPolicyDocument_Dimension != null)
            {
                requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_Dimension = cmdletContext.InstanceFcaPolicyDocument_Dimension;
            }
            if (requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_Dimension != null)
            {
                request.InstanceFcaPolicyDocument.Dimensions = requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_Dimension;
                requestInstanceFcaPolicyDocumentIsNull = false;
            }
            List<System.String> requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_ReportingGranularity = null;
            if (cmdletContext.InstanceFcaPolicyDocument_ReportingGranularity != null)
            {
                requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_ReportingGranularity = cmdletContext.InstanceFcaPolicyDocument_ReportingGranularity;
            }
            if (requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_ReportingGranularity != null)
            {
                request.InstanceFcaPolicyDocument.ReportingGranularity = requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_ReportingGranularity;
                requestInstanceFcaPolicyDocumentIsNull = false;
            }
            Amazon.EC2.Model.FlexCostAllocationCidrRangeSpecifications requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_CidrRangeSpecifications = null;
            
             // populate CidrRangeSpecifications
            var requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_CidrRangeSpecificationsIsNull = true;
            requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_CidrRangeSpecifications = new Amazon.EC2.Model.FlexCostAllocationCidrRangeSpecifications();
            List<Amazon.EC2.Model.FlexCostAllocationCidrMapping> requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_CidrRangeSpecifications_instanceFcaPolicyDocument_CidrRangeSpecifications_Prefix = null;
            if (cmdletContext.InstanceFcaPolicyDocument_CidrRangeSpecifications_Prefix != null)
            {
                requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_CidrRangeSpecifications_instanceFcaPolicyDocument_CidrRangeSpecifications_Prefix = cmdletContext.InstanceFcaPolicyDocument_CidrRangeSpecifications_Prefix;
            }
            if (requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_CidrRangeSpecifications_instanceFcaPolicyDocument_CidrRangeSpecifications_Prefix != null)
            {
                requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_CidrRangeSpecifications.Prefixes = requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_CidrRangeSpecifications_instanceFcaPolicyDocument_CidrRangeSpecifications_Prefix;
                requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_CidrRangeSpecificationsIsNull = false;
            }
            System.String requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_CidrRangeSpecifications_instanceFcaPolicyDocument_CidrRangeSpecifications_PrefixesType = null;
            if (cmdletContext.InstanceFcaPolicyDocument_CidrRangeSpecifications_PrefixesType != null)
            {
                requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_CidrRangeSpecifications_instanceFcaPolicyDocument_CidrRangeSpecifications_PrefixesType = cmdletContext.InstanceFcaPolicyDocument_CidrRangeSpecifications_PrefixesType;
            }
            if (requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_CidrRangeSpecifications_instanceFcaPolicyDocument_CidrRangeSpecifications_PrefixesType != null)
            {
                requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_CidrRangeSpecifications.PrefixesType = requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_CidrRangeSpecifications_instanceFcaPolicyDocument_CidrRangeSpecifications_PrefixesType;
                requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_CidrRangeSpecificationsIsNull = false;
            }
             // determine if requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_CidrRangeSpecifications should be set to null
            if (requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_CidrRangeSpecificationsIsNull)
            {
                requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_CidrRangeSpecifications = null;
            }
            if (requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_CidrRangeSpecifications != null)
            {
                request.InstanceFcaPolicyDocument.CidrRangeSpecifications = requestInstanceFcaPolicyDocument_instanceFcaPolicyDocument_CidrRangeSpecifications;
                requestInstanceFcaPolicyDocumentIsNull = false;
            }
             // determine if request.InstanceFcaPolicyDocument should be set to null
            if (requestInstanceFcaPolicyDocumentIsNull)
            {
                request.InstanceFcaPolicyDocument = null;
            }
            
             // populate NatFcaPolicyDocument
            var requestNatFcaPolicyDocumentIsNull = true;
            request.NatFcaPolicyDocument = new Amazon.EC2.Model.NatFlexCostAllocationPolicyDocument();
            List<System.String> requestNatFcaPolicyDocument_natFcaPolicyDocument_Dimension = null;
            if (cmdletContext.NatFcaPolicyDocument_Dimension != null)
            {
                requestNatFcaPolicyDocument_natFcaPolicyDocument_Dimension = cmdletContext.NatFcaPolicyDocument_Dimension;
            }
            if (requestNatFcaPolicyDocument_natFcaPolicyDocument_Dimension != null)
            {
                request.NatFcaPolicyDocument.Dimensions = requestNatFcaPolicyDocument_natFcaPolicyDocument_Dimension;
                requestNatFcaPolicyDocumentIsNull = false;
            }
            List<System.String> requestNatFcaPolicyDocument_natFcaPolicyDocument_ReportingGranularity = null;
            if (cmdletContext.NatFcaPolicyDocument_ReportingGranularity != null)
            {
                requestNatFcaPolicyDocument_natFcaPolicyDocument_ReportingGranularity = cmdletContext.NatFcaPolicyDocument_ReportingGranularity;
            }
            if (requestNatFcaPolicyDocument_natFcaPolicyDocument_ReportingGranularity != null)
            {
                request.NatFcaPolicyDocument.ReportingGranularity = requestNatFcaPolicyDocument_natFcaPolicyDocument_ReportingGranularity;
                requestNatFcaPolicyDocumentIsNull = false;
            }
            Amazon.EC2.Model.FlexCostAllocationCidrRangeSpecifications requestNatFcaPolicyDocument_natFcaPolicyDocument_CidrRangeSpecifications = null;
            
             // populate CidrRangeSpecifications
            var requestNatFcaPolicyDocument_natFcaPolicyDocument_CidrRangeSpecificationsIsNull = true;
            requestNatFcaPolicyDocument_natFcaPolicyDocument_CidrRangeSpecifications = new Amazon.EC2.Model.FlexCostAllocationCidrRangeSpecifications();
            List<Amazon.EC2.Model.FlexCostAllocationCidrMapping> requestNatFcaPolicyDocument_natFcaPolicyDocument_CidrRangeSpecifications_natFcaPolicyDocument_CidrRangeSpecifications_Prefix = null;
            if (cmdletContext.NatFcaPolicyDocument_CidrRangeSpecifications_Prefix != null)
            {
                requestNatFcaPolicyDocument_natFcaPolicyDocument_CidrRangeSpecifications_natFcaPolicyDocument_CidrRangeSpecifications_Prefix = cmdletContext.NatFcaPolicyDocument_CidrRangeSpecifications_Prefix;
            }
            if (requestNatFcaPolicyDocument_natFcaPolicyDocument_CidrRangeSpecifications_natFcaPolicyDocument_CidrRangeSpecifications_Prefix != null)
            {
                requestNatFcaPolicyDocument_natFcaPolicyDocument_CidrRangeSpecifications.Prefixes = requestNatFcaPolicyDocument_natFcaPolicyDocument_CidrRangeSpecifications_natFcaPolicyDocument_CidrRangeSpecifications_Prefix;
                requestNatFcaPolicyDocument_natFcaPolicyDocument_CidrRangeSpecificationsIsNull = false;
            }
            System.String requestNatFcaPolicyDocument_natFcaPolicyDocument_CidrRangeSpecifications_natFcaPolicyDocument_CidrRangeSpecifications_PrefixesType = null;
            if (cmdletContext.NatFcaPolicyDocument_CidrRangeSpecifications_PrefixesType != null)
            {
                requestNatFcaPolicyDocument_natFcaPolicyDocument_CidrRangeSpecifications_natFcaPolicyDocument_CidrRangeSpecifications_PrefixesType = cmdletContext.NatFcaPolicyDocument_CidrRangeSpecifications_PrefixesType;
            }
            if (requestNatFcaPolicyDocument_natFcaPolicyDocument_CidrRangeSpecifications_natFcaPolicyDocument_CidrRangeSpecifications_PrefixesType != null)
            {
                requestNatFcaPolicyDocument_natFcaPolicyDocument_CidrRangeSpecifications.PrefixesType = requestNatFcaPolicyDocument_natFcaPolicyDocument_CidrRangeSpecifications_natFcaPolicyDocument_CidrRangeSpecifications_PrefixesType;
                requestNatFcaPolicyDocument_natFcaPolicyDocument_CidrRangeSpecificationsIsNull = false;
            }
             // determine if requestNatFcaPolicyDocument_natFcaPolicyDocument_CidrRangeSpecifications should be set to null
            if (requestNatFcaPolicyDocument_natFcaPolicyDocument_CidrRangeSpecificationsIsNull)
            {
                requestNatFcaPolicyDocument_natFcaPolicyDocument_CidrRangeSpecifications = null;
            }
            if (requestNatFcaPolicyDocument_natFcaPolicyDocument_CidrRangeSpecifications != null)
            {
                request.NatFcaPolicyDocument.CidrRangeSpecifications = requestNatFcaPolicyDocument_natFcaPolicyDocument_CidrRangeSpecifications;
                requestNatFcaPolicyDocumentIsNull = false;
            }
             // determine if request.NatFcaPolicyDocument should be set to null
            if (requestNatFcaPolicyDocumentIsNull)
            {
                request.NatFcaPolicyDocument = null;
            }
            if (cmdletContext.NetworkResourceType != null)
            {
                request.NetworkResourceType = cmdletContext.NetworkResourceType;
            }
            
             // populate PcxFcaPolicyDocument
            var requestPcxFcaPolicyDocumentIsNull = true;
            request.PcxFcaPolicyDocument = new Amazon.EC2.Model.PcxFlexCostAllocationPolicyDocument();
            List<System.String> requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_Dimension = null;
            if (cmdletContext.PcxFcaPolicyDocument_Dimension != null)
            {
                requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_Dimension = cmdletContext.PcxFcaPolicyDocument_Dimension;
            }
            if (requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_Dimension != null)
            {
                request.PcxFcaPolicyDocument.Dimensions = requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_Dimension;
                requestPcxFcaPolicyDocumentIsNull = false;
            }
            List<System.String> requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_ReportingGranularity = null;
            if (cmdletContext.PcxFcaPolicyDocument_ReportingGranularity != null)
            {
                requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_ReportingGranularity = cmdletContext.PcxFcaPolicyDocument_ReportingGranularity;
            }
            if (requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_ReportingGranularity != null)
            {
                request.PcxFcaPolicyDocument.ReportingGranularity = requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_ReportingGranularity;
                requestPcxFcaPolicyDocumentIsNull = false;
            }
            Amazon.EC2.Model.FlexCostAllocationCidrRangeSpecifications requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_CidrRangeSpecifications = null;
            
             // populate CidrRangeSpecifications
            var requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_CidrRangeSpecificationsIsNull = true;
            requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_CidrRangeSpecifications = new Amazon.EC2.Model.FlexCostAllocationCidrRangeSpecifications();
            List<Amazon.EC2.Model.FlexCostAllocationCidrMapping> requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_CidrRangeSpecifications_pcxFcaPolicyDocument_CidrRangeSpecifications_Prefix = null;
            if (cmdletContext.PcxFcaPolicyDocument_CidrRangeSpecifications_Prefix != null)
            {
                requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_CidrRangeSpecifications_pcxFcaPolicyDocument_CidrRangeSpecifications_Prefix = cmdletContext.PcxFcaPolicyDocument_CidrRangeSpecifications_Prefix;
            }
            if (requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_CidrRangeSpecifications_pcxFcaPolicyDocument_CidrRangeSpecifications_Prefix != null)
            {
                requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_CidrRangeSpecifications.Prefixes = requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_CidrRangeSpecifications_pcxFcaPolicyDocument_CidrRangeSpecifications_Prefix;
                requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_CidrRangeSpecificationsIsNull = false;
            }
            System.String requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_CidrRangeSpecifications_pcxFcaPolicyDocument_CidrRangeSpecifications_PrefixesType = null;
            if (cmdletContext.PcxFcaPolicyDocument_CidrRangeSpecifications_PrefixesType != null)
            {
                requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_CidrRangeSpecifications_pcxFcaPolicyDocument_CidrRangeSpecifications_PrefixesType = cmdletContext.PcxFcaPolicyDocument_CidrRangeSpecifications_PrefixesType;
            }
            if (requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_CidrRangeSpecifications_pcxFcaPolicyDocument_CidrRangeSpecifications_PrefixesType != null)
            {
                requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_CidrRangeSpecifications.PrefixesType = requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_CidrRangeSpecifications_pcxFcaPolicyDocument_CidrRangeSpecifications_PrefixesType;
                requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_CidrRangeSpecificationsIsNull = false;
            }
             // determine if requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_CidrRangeSpecifications should be set to null
            if (requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_CidrRangeSpecificationsIsNull)
            {
                requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_CidrRangeSpecifications = null;
            }
            if (requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_CidrRangeSpecifications != null)
            {
                request.PcxFcaPolicyDocument.CidrRangeSpecifications = requestPcxFcaPolicyDocument_pcxFcaPolicyDocument_CidrRangeSpecifications;
                requestPcxFcaPolicyDocumentIsNull = false;
            }
             // determine if request.PcxFcaPolicyDocument should be set to null
            if (requestPcxFcaPolicyDocumentIsNull)
            {
                request.PcxFcaPolicyDocument = null;
            }
            if (cmdletContext.ShowBackEnabled != null)
            {
                request.ShowBackEnabled = cmdletContext.ShowBackEnabled.Value;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
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
        
        private Amazon.EC2.Model.CreateNetworkingFlexCostAllocationPolicyResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateNetworkingFlexCostAllocationPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "CreateNetworkingFlexCostAllocationPolicy");
            try
            {
                return client.CreateNetworkingFlexCostAllocationPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? DryRun { get; set; }
            public List<Amazon.EC2.Model.FlexCostAllocationCidrMapping> InstanceFcaPolicyDocument_CidrRangeSpecifications_Prefix { get; set; }
            public System.String InstanceFcaPolicyDocument_CidrRangeSpecifications_PrefixesType { get; set; }
            public List<System.String> InstanceFcaPolicyDocument_Dimension { get; set; }
            public List<System.String> InstanceFcaPolicyDocument_ReportingGranularity { get; set; }
            public List<Amazon.EC2.Model.FlexCostAllocationCidrMapping> NatFcaPolicyDocument_CidrRangeSpecifications_Prefix { get; set; }
            public System.String NatFcaPolicyDocument_CidrRangeSpecifications_PrefixesType { get; set; }
            public List<System.String> NatFcaPolicyDocument_Dimension { get; set; }
            public List<System.String> NatFcaPolicyDocument_ReportingGranularity { get; set; }
            public Amazon.EC2.FlexCostAllocationNetworkResourceType NetworkResourceType { get; set; }
            public List<Amazon.EC2.Model.FlexCostAllocationCidrMapping> PcxFcaPolicyDocument_CidrRangeSpecifications_Prefix { get; set; }
            public System.String PcxFcaPolicyDocument_CidrRangeSpecifications_PrefixesType { get; set; }
            public List<System.String> PcxFcaPolicyDocument_Dimension { get; set; }
            public List<System.String> PcxFcaPolicyDocument_ReportingGranularity { get; set; }
            public System.Boolean? ShowBackEnabled { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateNetworkingFlexCostAllocationPolicyResponse, NewEC2NetworkingFlexCostAllocationPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
