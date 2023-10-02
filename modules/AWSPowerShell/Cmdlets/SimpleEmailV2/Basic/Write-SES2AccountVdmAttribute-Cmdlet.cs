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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Update your Amazon SES account VDM attributes.
    /// 
    ///  
    /// <para>
    /// You can execute this operation no more than once per second.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "SES2AccountVdmAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) PutAccountVdmAttributes API operation.", Operation = new[] {"PutAccountVdmAttributes"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.PutAccountVdmAttributesResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmailV2.Model.PutAccountVdmAttributesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmailV2.Model.PutAccountVdmAttributesResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteSES2AccountVdmAttributeCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DashboardAttributes_EngagementMetric
        /// <summary>
        /// <para>
        /// <para>Specifies the status of your VDM engagement metrics collection. Can be one of the
        /// following:</para><ul><li><para><code>ENABLED</code> – Amazon SES enables engagement metrics for your account.</para></li><li><para><code>DISABLED</code> – Amazon SES disables engagement metrics for your account.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VdmAttributes_DashboardAttributes_EngagementMetrics")]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.FeatureStatus")]
        public Amazon.SimpleEmailV2.FeatureStatus DashboardAttributes_EngagementMetric { get; set; }
        #endregion
        
        #region Parameter GuardianAttributes_OptimizedSharedDelivery
        /// <summary>
        /// <para>
        /// <para>Specifies the status of your VDM optimized shared delivery. Can be one of the following:</para><ul><li><para><code>ENABLED</code> – Amazon SES enables optimized shared delivery for your account.</para></li><li><para><code>DISABLED</code> – Amazon SES disables optimized shared delivery for your account.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VdmAttributes_GuardianAttributes_OptimizedSharedDelivery")]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.FeatureStatus")]
        public Amazon.SimpleEmailV2.FeatureStatus GuardianAttributes_OptimizedSharedDelivery { get; set; }
        #endregion
        
        #region Parameter VdmAttributes_VdmEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies the status of your VDM configuration. Can be one of the following:</para><ul><li><para><code>ENABLED</code> – Amazon SES enables VDM for your account.</para></li><li><para><code>DISABLED</code> – Amazon SES disables VDM for your account.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.FeatureStatus")]
        public Amazon.SimpleEmailV2.FeatureStatus VdmAttributes_VdmEnabled { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.PutAccountVdmAttributesResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VdmAttributes_VdmEnabled parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VdmAttributes_VdmEnabled' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VdmAttributes_VdmEnabled' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VdmAttributes_VdmEnabled), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SES2AccountVdmAttribute (PutAccountVdmAttributes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.PutAccountVdmAttributesResponse, WriteSES2AccountVdmAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VdmAttributes_VdmEnabled;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DashboardAttributes_EngagementMetric = this.DashboardAttributes_EngagementMetric;
            context.GuardianAttributes_OptimizedSharedDelivery = this.GuardianAttributes_OptimizedSharedDelivery;
            context.VdmAttributes_VdmEnabled = this.VdmAttributes_VdmEnabled;
            #if MODULAR
            if (this.VdmAttributes_VdmEnabled == null && ParameterWasBound(nameof(this.VdmAttributes_VdmEnabled)))
            {
                WriteWarning("You are passing $null as a value for parameter VdmAttributes_VdmEnabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.SimpleEmailV2.Model.PutAccountVdmAttributesRequest();
            
            
             // populate VdmAttributes
            var requestVdmAttributesIsNull = true;
            request.VdmAttributes = new Amazon.SimpleEmailV2.Model.VdmAttributes();
            Amazon.SimpleEmailV2.FeatureStatus requestVdmAttributes_vdmAttributes_VdmEnabled = null;
            if (cmdletContext.VdmAttributes_VdmEnabled != null)
            {
                requestVdmAttributes_vdmAttributes_VdmEnabled = cmdletContext.VdmAttributes_VdmEnabled;
            }
            if (requestVdmAttributes_vdmAttributes_VdmEnabled != null)
            {
                request.VdmAttributes.VdmEnabled = requestVdmAttributes_vdmAttributes_VdmEnabled;
                requestVdmAttributesIsNull = false;
            }
            Amazon.SimpleEmailV2.Model.DashboardAttributes requestVdmAttributes_vdmAttributes_DashboardAttributes = null;
            
             // populate DashboardAttributes
            var requestVdmAttributes_vdmAttributes_DashboardAttributesIsNull = true;
            requestVdmAttributes_vdmAttributes_DashboardAttributes = new Amazon.SimpleEmailV2.Model.DashboardAttributes();
            Amazon.SimpleEmailV2.FeatureStatus requestVdmAttributes_vdmAttributes_DashboardAttributes_dashboardAttributes_EngagementMetric = null;
            if (cmdletContext.DashboardAttributes_EngagementMetric != null)
            {
                requestVdmAttributes_vdmAttributes_DashboardAttributes_dashboardAttributes_EngagementMetric = cmdletContext.DashboardAttributes_EngagementMetric;
            }
            if (requestVdmAttributes_vdmAttributes_DashboardAttributes_dashboardAttributes_EngagementMetric != null)
            {
                requestVdmAttributes_vdmAttributes_DashboardAttributes.EngagementMetrics = requestVdmAttributes_vdmAttributes_DashboardAttributes_dashboardAttributes_EngagementMetric;
                requestVdmAttributes_vdmAttributes_DashboardAttributesIsNull = false;
            }
             // determine if requestVdmAttributes_vdmAttributes_DashboardAttributes should be set to null
            if (requestVdmAttributes_vdmAttributes_DashboardAttributesIsNull)
            {
                requestVdmAttributes_vdmAttributes_DashboardAttributes = null;
            }
            if (requestVdmAttributes_vdmAttributes_DashboardAttributes != null)
            {
                request.VdmAttributes.DashboardAttributes = requestVdmAttributes_vdmAttributes_DashboardAttributes;
                requestVdmAttributesIsNull = false;
            }
            Amazon.SimpleEmailV2.Model.GuardianAttributes requestVdmAttributes_vdmAttributes_GuardianAttributes = null;
            
             // populate GuardianAttributes
            var requestVdmAttributes_vdmAttributes_GuardianAttributesIsNull = true;
            requestVdmAttributes_vdmAttributes_GuardianAttributes = new Amazon.SimpleEmailV2.Model.GuardianAttributes();
            Amazon.SimpleEmailV2.FeatureStatus requestVdmAttributes_vdmAttributes_GuardianAttributes_guardianAttributes_OptimizedSharedDelivery = null;
            if (cmdletContext.GuardianAttributes_OptimizedSharedDelivery != null)
            {
                requestVdmAttributes_vdmAttributes_GuardianAttributes_guardianAttributes_OptimizedSharedDelivery = cmdletContext.GuardianAttributes_OptimizedSharedDelivery;
            }
            if (requestVdmAttributes_vdmAttributes_GuardianAttributes_guardianAttributes_OptimizedSharedDelivery != null)
            {
                requestVdmAttributes_vdmAttributes_GuardianAttributes.OptimizedSharedDelivery = requestVdmAttributes_vdmAttributes_GuardianAttributes_guardianAttributes_OptimizedSharedDelivery;
                requestVdmAttributes_vdmAttributes_GuardianAttributesIsNull = false;
            }
             // determine if requestVdmAttributes_vdmAttributes_GuardianAttributes should be set to null
            if (requestVdmAttributes_vdmAttributes_GuardianAttributesIsNull)
            {
                requestVdmAttributes_vdmAttributes_GuardianAttributes = null;
            }
            if (requestVdmAttributes_vdmAttributes_GuardianAttributes != null)
            {
                request.VdmAttributes.GuardianAttributes = requestVdmAttributes_vdmAttributes_GuardianAttributes;
                requestVdmAttributesIsNull = false;
            }
             // determine if request.VdmAttributes should be set to null
            if (requestVdmAttributesIsNull)
            {
                request.VdmAttributes = null;
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
        
        private Amazon.SimpleEmailV2.Model.PutAccountVdmAttributesResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.PutAccountVdmAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "PutAccountVdmAttributes");
            try
            {
                #if DESKTOP
                return client.PutAccountVdmAttributes(request);
                #elif CORECLR
                return client.PutAccountVdmAttributesAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SimpleEmailV2.FeatureStatus DashboardAttributes_EngagementMetric { get; set; }
            public Amazon.SimpleEmailV2.FeatureStatus GuardianAttributes_OptimizedSharedDelivery { get; set; }
            public Amazon.SimpleEmailV2.FeatureStatus VdmAttributes_VdmEnabled { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.PutAccountVdmAttributesResponse, WriteSES2AccountVdmAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
