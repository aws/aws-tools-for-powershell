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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Updates a continuous deployment policy. You can update a continuous deployment policy
    /// to enable or disable it, to change the percentage of traffic that it sends to the
    /// staging distribution, or to change the staging distribution that it sends traffic
    /// to.
    /// 
    ///  
    /// <para>
    /// When you update a continuous deployment policy configuration, all the fields are updated
    /// with the values that are provided in the request. You cannot update some fields independent
    /// of others. To update a continuous deployment policy configuration:
    /// </para><ol><li><para>
    /// Use <c>GetContinuousDeploymentPolicyConfig</c> to get the current configuration.
    /// </para></li><li><para>
    /// Locally modify the fields in the continuous deployment policy configuration that you
    /// want to update.
    /// </para></li><li><para>
    /// Use <c>UpdateContinuousDeploymentPolicy</c>, providing the entire continuous deployment
    /// policy configuration, including the fields that you modified and those that you didn't.
    /// </para></li></ol>
    /// </summary>
    [Cmdlet("Update", "CFContinuousDeploymentPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.ContinuousDeploymentPolicy")]
    [AWSCmdlet("Calls the Amazon CloudFront UpdateContinuousDeploymentPolicy API operation.", Operation = new[] {"UpdateContinuousDeploymentPolicy"}, SelectReturnType = typeof(Amazon.CloudFront.Model.UpdateContinuousDeploymentPolicyResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.ContinuousDeploymentPolicy or Amazon.CloudFront.Model.UpdateContinuousDeploymentPolicyResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.ContinuousDeploymentPolicy object.",
        "The service call response (type Amazon.CloudFront.Model.UpdateContinuousDeploymentPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCFContinuousDeploymentPolicyCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContinuousDeploymentPolicyConfig_Enabled
        /// <summary>
        /// <para>
        /// <para>A Boolean that indicates whether this continuous deployment policy is enabled (in
        /// effect). When this value is <c>true</c>, this policy is enabled and in effect. When
        /// this value is <c>false</c>, this policy is not enabled and has no effect.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? ContinuousDeploymentPolicyConfig_Enabled { get; set; }
        #endregion
        
        #region Parameter SingleHeaderConfig_Header
        /// <summary>
        /// <para>
        /// <para>The request header name that you want CloudFront to send to your staging distribution.
        /// The header must contain the prefix <c>aws-cf-cd-</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContinuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfig_Header")]
        public System.String SingleHeaderConfig_Header { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The identifier of the continuous deployment policy that you are updating.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter SessionStickinessConfig_IdleTTL
        /// <summary>
        /// <para>
        /// <para>The amount of time after which you want sessions to cease if no requests are received.
        /// Allowed values are 300–3600 seconds (5–60 minutes).</para><para>The value must be less than or equal to <c>MaximumTTL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContinuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfig_IdleTTL")]
        public System.Int32? SessionStickinessConfig_IdleTTL { get; set; }
        #endregion
        
        #region Parameter IfMatch
        /// <summary>
        /// <para>
        /// <para>The current version (<c>ETag</c> value) of the continuous deployment policy that you
        /// are updating.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IfMatch { get; set; }
        #endregion
        
        #region Parameter StagingDistributionDnsNames_Item
        /// <summary>
        /// <para>
        /// <para>The CloudFront domain name of the staging distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContinuousDeploymentPolicyConfig_StagingDistributionDnsNames_Items")]
        public System.String[] StagingDistributionDnsNames_Item { get; set; }
        #endregion
        
        #region Parameter SessionStickinessConfig_MaximumTTL
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time to consider requests from the viewer as being part of the
        /// same session. Allowed values are 300–3600 seconds (5–60 minutes).</para><para>The value must be greater than or equal to <c>IdleTTL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContinuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfig_MaximumTTL")]
        public System.Int32? SessionStickinessConfig_MaximumTTL { get; set; }
        #endregion
        
        #region Parameter StagingDistributionDnsNames_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of CloudFront domain names in your staging distribution.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ContinuousDeploymentPolicyConfig_StagingDistributionDnsNames_Quantity")]
        public System.Int32? StagingDistributionDnsNames_Quantity { get; set; }
        #endregion
        
        #region Parameter TrafficConfig_Type
        /// <summary>
        /// <para>
        /// <para>The type of traffic configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContinuousDeploymentPolicyConfig_TrafficConfig_Type")]
        [AWSConstantClassSource("Amazon.CloudFront.ContinuousDeploymentPolicyType")]
        public Amazon.CloudFront.ContinuousDeploymentPolicyType TrafficConfig_Type { get; set; }
        #endregion
        
        #region Parameter SingleHeaderConfig_Value
        /// <summary>
        /// <para>
        /// <para>The request header value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContinuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfig_Value")]
        public System.String SingleHeaderConfig_Value { get; set; }
        #endregion
        
        #region Parameter SingleWeightConfig_Weight
        /// <summary>
        /// <para>
        /// <para>The percentage of traffic to send to a staging distribution, expressed as a decimal
        /// number between 0 and 0.15. For example, a value of 0.10 means 10% of traffic is sent
        /// to the staging distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContinuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_Weight")]
        public System.Single? SingleWeightConfig_Weight { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContinuousDeploymentPolicy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.UpdateContinuousDeploymentPolicyResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.UpdateContinuousDeploymentPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContinuousDeploymentPolicy";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFContinuousDeploymentPolicy (UpdateContinuousDeploymentPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.UpdateContinuousDeploymentPolicyResponse, UpdateCFContinuousDeploymentPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContinuousDeploymentPolicyConfig_Enabled = this.ContinuousDeploymentPolicyConfig_Enabled;
            #if MODULAR
            if (this.ContinuousDeploymentPolicyConfig_Enabled == null && ParameterWasBound(nameof(this.ContinuousDeploymentPolicyConfig_Enabled)))
            {
                WriteWarning("You are passing $null as a value for parameter ContinuousDeploymentPolicyConfig_Enabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.StagingDistributionDnsNames_Item != null)
            {
                context.StagingDistributionDnsNames_Item = new List<System.String>(this.StagingDistributionDnsNames_Item);
            }
            context.StagingDistributionDnsNames_Quantity = this.StagingDistributionDnsNames_Quantity;
            #if MODULAR
            if (this.StagingDistributionDnsNames_Quantity == null && ParameterWasBound(nameof(this.StagingDistributionDnsNames_Quantity)))
            {
                WriteWarning("You are passing $null as a value for parameter StagingDistributionDnsNames_Quantity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SingleHeaderConfig_Header = this.SingleHeaderConfig_Header;
            context.SingleHeaderConfig_Value = this.SingleHeaderConfig_Value;
            context.SessionStickinessConfig_IdleTTL = this.SessionStickinessConfig_IdleTTL;
            context.SessionStickinessConfig_MaximumTTL = this.SessionStickinessConfig_MaximumTTL;
            context.SingleWeightConfig_Weight = this.SingleWeightConfig_Weight;
            context.TrafficConfig_Type = this.TrafficConfig_Type;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IfMatch = this.IfMatch;
            
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
            var request = new Amazon.CloudFront.Model.UpdateContinuousDeploymentPolicyRequest();
            
            
             // populate ContinuousDeploymentPolicyConfig
            var requestContinuousDeploymentPolicyConfigIsNull = true;
            request.ContinuousDeploymentPolicyConfig = new Amazon.CloudFront.Model.ContinuousDeploymentPolicyConfig();
            System.Boolean? requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_Enabled = null;
            if (cmdletContext.ContinuousDeploymentPolicyConfig_Enabled != null)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_Enabled = cmdletContext.ContinuousDeploymentPolicyConfig_Enabled.Value;
            }
            if (requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_Enabled != null)
            {
                request.ContinuousDeploymentPolicyConfig.Enabled = requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_Enabled.Value;
                requestContinuousDeploymentPolicyConfigIsNull = false;
            }
            Amazon.CloudFront.Model.StagingDistributionDnsNames requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_StagingDistributionDnsNames = null;
            
             // populate StagingDistributionDnsNames
            var requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_StagingDistributionDnsNamesIsNull = true;
            requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_StagingDistributionDnsNames = new Amazon.CloudFront.Model.StagingDistributionDnsNames();
            List<System.String> requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_StagingDistributionDnsNames_stagingDistributionDnsNames_Item = null;
            if (cmdletContext.StagingDistributionDnsNames_Item != null)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_StagingDistributionDnsNames_stagingDistributionDnsNames_Item = cmdletContext.StagingDistributionDnsNames_Item;
            }
            if (requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_StagingDistributionDnsNames_stagingDistributionDnsNames_Item != null)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_StagingDistributionDnsNames.Items = requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_StagingDistributionDnsNames_stagingDistributionDnsNames_Item;
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_StagingDistributionDnsNamesIsNull = false;
            }
            System.Int32? requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_StagingDistributionDnsNames_stagingDistributionDnsNames_Quantity = null;
            if (cmdletContext.StagingDistributionDnsNames_Quantity != null)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_StagingDistributionDnsNames_stagingDistributionDnsNames_Quantity = cmdletContext.StagingDistributionDnsNames_Quantity.Value;
            }
            if (requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_StagingDistributionDnsNames_stagingDistributionDnsNames_Quantity != null)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_StagingDistributionDnsNames.Quantity = requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_StagingDistributionDnsNames_stagingDistributionDnsNames_Quantity.Value;
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_StagingDistributionDnsNamesIsNull = false;
            }
             // determine if requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_StagingDistributionDnsNames should be set to null
            if (requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_StagingDistributionDnsNamesIsNull)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_StagingDistributionDnsNames = null;
            }
            if (requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_StagingDistributionDnsNames != null)
            {
                request.ContinuousDeploymentPolicyConfig.StagingDistributionDnsNames = requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_StagingDistributionDnsNames;
                requestContinuousDeploymentPolicyConfigIsNull = false;
            }
            Amazon.CloudFront.Model.TrafficConfig requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig = null;
            
             // populate TrafficConfig
            var requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfigIsNull = true;
            requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig = new Amazon.CloudFront.Model.TrafficConfig();
            Amazon.CloudFront.ContinuousDeploymentPolicyType requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_trafficConfig_Type = null;
            if (cmdletContext.TrafficConfig_Type != null)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_trafficConfig_Type = cmdletContext.TrafficConfig_Type;
            }
            if (requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_trafficConfig_Type != null)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig.Type = requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_trafficConfig_Type;
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfigIsNull = false;
            }
            Amazon.CloudFront.Model.ContinuousDeploymentSingleHeaderConfig requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfig = null;
            
             // populate SingleHeaderConfig
            var requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfigIsNull = true;
            requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfig = new Amazon.CloudFront.Model.ContinuousDeploymentSingleHeaderConfig();
            System.String requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfig_singleHeaderConfig_Header = null;
            if (cmdletContext.SingleHeaderConfig_Header != null)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfig_singleHeaderConfig_Header = cmdletContext.SingleHeaderConfig_Header;
            }
            if (requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfig_singleHeaderConfig_Header != null)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfig.Header = requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfig_singleHeaderConfig_Header;
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfigIsNull = false;
            }
            System.String requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfig_singleHeaderConfig_Value = null;
            if (cmdletContext.SingleHeaderConfig_Value != null)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfig_singleHeaderConfig_Value = cmdletContext.SingleHeaderConfig_Value;
            }
            if (requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfig_singleHeaderConfig_Value != null)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfig.Value = requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfig_singleHeaderConfig_Value;
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfigIsNull = false;
            }
             // determine if requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfig should be set to null
            if (requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfigIsNull)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfig = null;
            }
            if (requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfig != null)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig.SingleHeaderConfig = requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleHeaderConfig;
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfigIsNull = false;
            }
            Amazon.CloudFront.Model.ContinuousDeploymentSingleWeightConfig requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig = null;
            
             // populate SingleWeightConfig
            var requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfigIsNull = true;
            requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig = new Amazon.CloudFront.Model.ContinuousDeploymentSingleWeightConfig();
            System.Single? requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_singleWeightConfig_Weight = null;
            if (cmdletContext.SingleWeightConfig_Weight != null)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_singleWeightConfig_Weight = cmdletContext.SingleWeightConfig_Weight.Value;
            }
            if (requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_singleWeightConfig_Weight != null)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig.Weight = requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_singleWeightConfig_Weight.Value;
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfigIsNull = false;
            }
            Amazon.CloudFront.Model.SessionStickinessConfig requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfig = null;
            
             // populate SessionStickinessConfig
            var requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfigIsNull = true;
            requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfig = new Amazon.CloudFront.Model.SessionStickinessConfig();
            System.Int32? requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfig_sessionStickinessConfig_IdleTTL = null;
            if (cmdletContext.SessionStickinessConfig_IdleTTL != null)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfig_sessionStickinessConfig_IdleTTL = cmdletContext.SessionStickinessConfig_IdleTTL.Value;
            }
            if (requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfig_sessionStickinessConfig_IdleTTL != null)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfig.IdleTTL = requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfig_sessionStickinessConfig_IdleTTL.Value;
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfigIsNull = false;
            }
            System.Int32? requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfig_sessionStickinessConfig_MaximumTTL = null;
            if (cmdletContext.SessionStickinessConfig_MaximumTTL != null)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfig_sessionStickinessConfig_MaximumTTL = cmdletContext.SessionStickinessConfig_MaximumTTL.Value;
            }
            if (requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfig_sessionStickinessConfig_MaximumTTL != null)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfig.MaximumTTL = requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfig_sessionStickinessConfig_MaximumTTL.Value;
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfigIsNull = false;
            }
             // determine if requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfig should be set to null
            if (requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfigIsNull)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfig = null;
            }
            if (requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfig != null)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig.SessionStickinessConfig = requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig_SessionStickinessConfig;
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfigIsNull = false;
            }
             // determine if requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig should be set to null
            if (requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfigIsNull)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig = null;
            }
            if (requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig != null)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig.SingleWeightConfig = requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig_continuousDeploymentPolicyConfig_TrafficConfig_SingleWeightConfig;
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfigIsNull = false;
            }
             // determine if requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig should be set to null
            if (requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfigIsNull)
            {
                requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig = null;
            }
            if (requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig != null)
            {
                request.ContinuousDeploymentPolicyConfig.TrafficConfig = requestContinuousDeploymentPolicyConfig_continuousDeploymentPolicyConfig_TrafficConfig;
                requestContinuousDeploymentPolicyConfigIsNull = false;
            }
             // determine if request.ContinuousDeploymentPolicyConfig should be set to null
            if (requestContinuousDeploymentPolicyConfigIsNull)
            {
                request.ContinuousDeploymentPolicyConfig = null;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.IfMatch != null)
            {
                request.IfMatch = cmdletContext.IfMatch;
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
        
        private Amazon.CloudFront.Model.UpdateContinuousDeploymentPolicyResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.UpdateContinuousDeploymentPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "UpdateContinuousDeploymentPolicy");
            try
            {
                #if DESKTOP
                return client.UpdateContinuousDeploymentPolicy(request);
                #elif CORECLR
                return client.UpdateContinuousDeploymentPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? ContinuousDeploymentPolicyConfig_Enabled { get; set; }
            public List<System.String> StagingDistributionDnsNames_Item { get; set; }
            public System.Int32? StagingDistributionDnsNames_Quantity { get; set; }
            public System.String SingleHeaderConfig_Header { get; set; }
            public System.String SingleHeaderConfig_Value { get; set; }
            public System.Int32? SessionStickinessConfig_IdleTTL { get; set; }
            public System.Int32? SessionStickinessConfig_MaximumTTL { get; set; }
            public System.Single? SingleWeightConfig_Weight { get; set; }
            public Amazon.CloudFront.ContinuousDeploymentPolicyType TrafficConfig_Type { get; set; }
            public System.String Id { get; set; }
            public System.String IfMatch { get; set; }
            public System.Func<Amazon.CloudFront.Model.UpdateContinuousDeploymentPolicyResponse, UpdateCFContinuousDeploymentPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContinuousDeploymentPolicy;
        }
        
    }
}
