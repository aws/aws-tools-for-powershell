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
using Amazon.XRay;
using Amazon.XRay.Model;

namespace Amazon.PowerShell.Cmdlets.XR
{
    /// <summary>
    /// Modifies a sampling rule's configuration.
    /// </summary>
    [Cmdlet("Update", "XRSamplingRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.XRay.Model.SamplingRuleRecord")]
    [AWSCmdlet("Calls the AWS X-Ray UpdateSamplingRule API operation.", Operation = new[] {"UpdateSamplingRule"}, SelectReturnType = typeof(Amazon.XRay.Model.UpdateSamplingRuleResponse))]
    [AWSCmdletOutput("Amazon.XRay.Model.SamplingRuleRecord or Amazon.XRay.Model.UpdateSamplingRuleResponse",
        "This cmdlet returns an Amazon.XRay.Model.SamplingRuleRecord object.",
        "The service call response (type Amazon.XRay.Model.UpdateSamplingRuleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateXRSamplingRuleCmdlet : AmazonXRayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SamplingRuleUpdate_Attribute
        /// <summary>
        /// <para>
        /// <para>Matches attributes derived from the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SamplingRuleUpdate_Attributes")]
        public System.Collections.Hashtable SamplingRuleUpdate_Attribute { get; set; }
        #endregion
        
        #region Parameter SamplingRateBoost_CooldownWindowMinute
        /// <summary>
        /// <para>
        /// <para>Sets the time window (in minutes) in which only one sampling rate boost can be triggered.
        /// After a boost occurs, no further boosts are allowed until the next window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SamplingRuleUpdate_SamplingRateBoost_CooldownWindowMinutes")]
        public System.Int32? SamplingRateBoost_CooldownWindowMinute { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_FixedRate
        /// <summary>
        /// <para>
        /// <para>The percentage of matching requests to instrument, after the reservoir is exhausted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? SamplingRuleUpdate_FixedRate { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_Host
        /// <summary>
        /// <para>
        /// <para>Matches the hostname from a request URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SamplingRuleUpdate_Host { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_HTTPMethod
        /// <summary>
        /// <para>
        /// <para>Matches the HTTP method of a request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SamplingRuleUpdate_HTTPMethod { get; set; }
        #endregion
        
        #region Parameter SamplingRateBoost_MaxRate
        /// <summary>
        /// <para>
        /// <para>Defines max temporary sampling rate to apply when a boost is triggered. Calculated
        /// boost rate by X-Ray will be less than or equal to this max rate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SamplingRuleUpdate_SamplingRateBoost_MaxRate")]
        public System.Double? SamplingRateBoost_MaxRate { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_Priority
        /// <summary>
        /// <para>
        /// <para>The priority of the sampling rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SamplingRuleUpdate_Priority { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_ReservoirSize
        /// <summary>
        /// <para>
        /// <para>A fixed number of matching requests to instrument per second, prior to applying the
        /// fixed rate. The reservoir is not used directly by services, but applies to all services
        /// using the rule collectively.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SamplingRuleUpdate_ReservoirSize { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_ResourceARN
        /// <summary>
        /// <para>
        /// <para>Matches the ARN of the Amazon Web Services resource on which the service runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SamplingRuleUpdate_ResourceARN { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_RuleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the sampling rule. Specify a rule by either name or ARN, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SamplingRuleUpdate_RuleARN { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_RuleName
        /// <summary>
        /// <para>
        /// <para>The name of the sampling rule. Specify a rule by either name or ARN, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SamplingRuleUpdate_RuleName { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_ServiceName
        /// <summary>
        /// <para>
        /// <para>Matches the <c>name</c> that the service uses to identify itself in segments.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SamplingRuleUpdate_ServiceName { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_ServiceType
        /// <summary>
        /// <para>
        /// <para>Matches the <c>origin</c> that the service uses to identify its type in segments.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SamplingRuleUpdate_ServiceType { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_URLPath
        /// <summary>
        /// <para>
        /// <para>Matches the path from a request URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SamplingRuleUpdate_URLPath { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SamplingRuleRecord'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.XRay.Model.UpdateSamplingRuleResponse).
        /// Specifying the name of a property of type Amazon.XRay.Model.UpdateSamplingRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SamplingRuleRecord";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-XRSamplingRule (UpdateSamplingRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.XRay.Model.UpdateSamplingRuleResponse, UpdateXRSamplingRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.SamplingRuleUpdate_Attribute != null)
            {
                context.SamplingRuleUpdate_Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SamplingRuleUpdate_Attribute.Keys)
                {
                    context.SamplingRuleUpdate_Attribute.Add((String)hashKey, (System.String)(this.SamplingRuleUpdate_Attribute[hashKey]));
                }
            }
            context.SamplingRuleUpdate_FixedRate = this.SamplingRuleUpdate_FixedRate;
            context.SamplingRuleUpdate_Host = this.SamplingRuleUpdate_Host;
            context.SamplingRuleUpdate_HTTPMethod = this.SamplingRuleUpdate_HTTPMethod;
            context.SamplingRuleUpdate_Priority = this.SamplingRuleUpdate_Priority;
            context.SamplingRuleUpdate_ReservoirSize = this.SamplingRuleUpdate_ReservoirSize;
            context.SamplingRuleUpdate_ResourceARN = this.SamplingRuleUpdate_ResourceARN;
            context.SamplingRuleUpdate_RuleARN = this.SamplingRuleUpdate_RuleARN;
            context.SamplingRuleUpdate_RuleName = this.SamplingRuleUpdate_RuleName;
            context.SamplingRateBoost_CooldownWindowMinute = this.SamplingRateBoost_CooldownWindowMinute;
            context.SamplingRateBoost_MaxRate = this.SamplingRateBoost_MaxRate;
            context.SamplingRuleUpdate_ServiceName = this.SamplingRuleUpdate_ServiceName;
            context.SamplingRuleUpdate_ServiceType = this.SamplingRuleUpdate_ServiceType;
            context.SamplingRuleUpdate_URLPath = this.SamplingRuleUpdate_URLPath;
            
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
            var request = new Amazon.XRay.Model.UpdateSamplingRuleRequest();
            
            
             // populate SamplingRuleUpdate
            var requestSamplingRuleUpdateIsNull = true;
            request.SamplingRuleUpdate = new Amazon.XRay.Model.SamplingRuleUpdate();
            Dictionary<System.String, System.String> requestSamplingRuleUpdate_samplingRuleUpdate_Attribute = null;
            if (cmdletContext.SamplingRuleUpdate_Attribute != null)
            {
                requestSamplingRuleUpdate_samplingRuleUpdate_Attribute = cmdletContext.SamplingRuleUpdate_Attribute;
            }
            if (requestSamplingRuleUpdate_samplingRuleUpdate_Attribute != null)
            {
                request.SamplingRuleUpdate.Attributes = requestSamplingRuleUpdate_samplingRuleUpdate_Attribute;
                requestSamplingRuleUpdateIsNull = false;
            }
            System.Double? requestSamplingRuleUpdate_samplingRuleUpdate_FixedRate = null;
            if (cmdletContext.SamplingRuleUpdate_FixedRate != null)
            {
                requestSamplingRuleUpdate_samplingRuleUpdate_FixedRate = cmdletContext.SamplingRuleUpdate_FixedRate.Value;
            }
            if (requestSamplingRuleUpdate_samplingRuleUpdate_FixedRate != null)
            {
                request.SamplingRuleUpdate.FixedRate = requestSamplingRuleUpdate_samplingRuleUpdate_FixedRate.Value;
                requestSamplingRuleUpdateIsNull = false;
            }
            System.String requestSamplingRuleUpdate_samplingRuleUpdate_Host = null;
            if (cmdletContext.SamplingRuleUpdate_Host != null)
            {
                requestSamplingRuleUpdate_samplingRuleUpdate_Host = cmdletContext.SamplingRuleUpdate_Host;
            }
            if (requestSamplingRuleUpdate_samplingRuleUpdate_Host != null)
            {
                request.SamplingRuleUpdate.Host = requestSamplingRuleUpdate_samplingRuleUpdate_Host;
                requestSamplingRuleUpdateIsNull = false;
            }
            System.String requestSamplingRuleUpdate_samplingRuleUpdate_HTTPMethod = null;
            if (cmdletContext.SamplingRuleUpdate_HTTPMethod != null)
            {
                requestSamplingRuleUpdate_samplingRuleUpdate_HTTPMethod = cmdletContext.SamplingRuleUpdate_HTTPMethod;
            }
            if (requestSamplingRuleUpdate_samplingRuleUpdate_HTTPMethod != null)
            {
                request.SamplingRuleUpdate.HTTPMethod = requestSamplingRuleUpdate_samplingRuleUpdate_HTTPMethod;
                requestSamplingRuleUpdateIsNull = false;
            }
            System.Int32? requestSamplingRuleUpdate_samplingRuleUpdate_Priority = null;
            if (cmdletContext.SamplingRuleUpdate_Priority != null)
            {
                requestSamplingRuleUpdate_samplingRuleUpdate_Priority = cmdletContext.SamplingRuleUpdate_Priority.Value;
            }
            if (requestSamplingRuleUpdate_samplingRuleUpdate_Priority != null)
            {
                request.SamplingRuleUpdate.Priority = requestSamplingRuleUpdate_samplingRuleUpdate_Priority.Value;
                requestSamplingRuleUpdateIsNull = false;
            }
            System.Int32? requestSamplingRuleUpdate_samplingRuleUpdate_ReservoirSize = null;
            if (cmdletContext.SamplingRuleUpdate_ReservoirSize != null)
            {
                requestSamplingRuleUpdate_samplingRuleUpdate_ReservoirSize = cmdletContext.SamplingRuleUpdate_ReservoirSize.Value;
            }
            if (requestSamplingRuleUpdate_samplingRuleUpdate_ReservoirSize != null)
            {
                request.SamplingRuleUpdate.ReservoirSize = requestSamplingRuleUpdate_samplingRuleUpdate_ReservoirSize.Value;
                requestSamplingRuleUpdateIsNull = false;
            }
            System.String requestSamplingRuleUpdate_samplingRuleUpdate_ResourceARN = null;
            if (cmdletContext.SamplingRuleUpdate_ResourceARN != null)
            {
                requestSamplingRuleUpdate_samplingRuleUpdate_ResourceARN = cmdletContext.SamplingRuleUpdate_ResourceARN;
            }
            if (requestSamplingRuleUpdate_samplingRuleUpdate_ResourceARN != null)
            {
                request.SamplingRuleUpdate.ResourceARN = requestSamplingRuleUpdate_samplingRuleUpdate_ResourceARN;
                requestSamplingRuleUpdateIsNull = false;
            }
            System.String requestSamplingRuleUpdate_samplingRuleUpdate_RuleARN = null;
            if (cmdletContext.SamplingRuleUpdate_RuleARN != null)
            {
                requestSamplingRuleUpdate_samplingRuleUpdate_RuleARN = cmdletContext.SamplingRuleUpdate_RuleARN;
            }
            if (requestSamplingRuleUpdate_samplingRuleUpdate_RuleARN != null)
            {
                request.SamplingRuleUpdate.RuleARN = requestSamplingRuleUpdate_samplingRuleUpdate_RuleARN;
                requestSamplingRuleUpdateIsNull = false;
            }
            System.String requestSamplingRuleUpdate_samplingRuleUpdate_RuleName = null;
            if (cmdletContext.SamplingRuleUpdate_RuleName != null)
            {
                requestSamplingRuleUpdate_samplingRuleUpdate_RuleName = cmdletContext.SamplingRuleUpdate_RuleName;
            }
            if (requestSamplingRuleUpdate_samplingRuleUpdate_RuleName != null)
            {
                request.SamplingRuleUpdate.RuleName = requestSamplingRuleUpdate_samplingRuleUpdate_RuleName;
                requestSamplingRuleUpdateIsNull = false;
            }
            System.String requestSamplingRuleUpdate_samplingRuleUpdate_ServiceName = null;
            if (cmdletContext.SamplingRuleUpdate_ServiceName != null)
            {
                requestSamplingRuleUpdate_samplingRuleUpdate_ServiceName = cmdletContext.SamplingRuleUpdate_ServiceName;
            }
            if (requestSamplingRuleUpdate_samplingRuleUpdate_ServiceName != null)
            {
                request.SamplingRuleUpdate.ServiceName = requestSamplingRuleUpdate_samplingRuleUpdate_ServiceName;
                requestSamplingRuleUpdateIsNull = false;
            }
            System.String requestSamplingRuleUpdate_samplingRuleUpdate_ServiceType = null;
            if (cmdletContext.SamplingRuleUpdate_ServiceType != null)
            {
                requestSamplingRuleUpdate_samplingRuleUpdate_ServiceType = cmdletContext.SamplingRuleUpdate_ServiceType;
            }
            if (requestSamplingRuleUpdate_samplingRuleUpdate_ServiceType != null)
            {
                request.SamplingRuleUpdate.ServiceType = requestSamplingRuleUpdate_samplingRuleUpdate_ServiceType;
                requestSamplingRuleUpdateIsNull = false;
            }
            System.String requestSamplingRuleUpdate_samplingRuleUpdate_URLPath = null;
            if (cmdletContext.SamplingRuleUpdate_URLPath != null)
            {
                requestSamplingRuleUpdate_samplingRuleUpdate_URLPath = cmdletContext.SamplingRuleUpdate_URLPath;
            }
            if (requestSamplingRuleUpdate_samplingRuleUpdate_URLPath != null)
            {
                request.SamplingRuleUpdate.URLPath = requestSamplingRuleUpdate_samplingRuleUpdate_URLPath;
                requestSamplingRuleUpdateIsNull = false;
            }
            Amazon.XRay.Model.SamplingRateBoost requestSamplingRuleUpdate_samplingRuleUpdate_SamplingRateBoost = null;
            
             // populate SamplingRateBoost
            var requestSamplingRuleUpdate_samplingRuleUpdate_SamplingRateBoostIsNull = true;
            requestSamplingRuleUpdate_samplingRuleUpdate_SamplingRateBoost = new Amazon.XRay.Model.SamplingRateBoost();
            System.Int32? requestSamplingRuleUpdate_samplingRuleUpdate_SamplingRateBoost_samplingRateBoost_CooldownWindowMinute = null;
            if (cmdletContext.SamplingRateBoost_CooldownWindowMinute != null)
            {
                requestSamplingRuleUpdate_samplingRuleUpdate_SamplingRateBoost_samplingRateBoost_CooldownWindowMinute = cmdletContext.SamplingRateBoost_CooldownWindowMinute.Value;
            }
            if (requestSamplingRuleUpdate_samplingRuleUpdate_SamplingRateBoost_samplingRateBoost_CooldownWindowMinute != null)
            {
                requestSamplingRuleUpdate_samplingRuleUpdate_SamplingRateBoost.CooldownWindowMinutes = requestSamplingRuleUpdate_samplingRuleUpdate_SamplingRateBoost_samplingRateBoost_CooldownWindowMinute.Value;
                requestSamplingRuleUpdate_samplingRuleUpdate_SamplingRateBoostIsNull = false;
            }
            System.Double? requestSamplingRuleUpdate_samplingRuleUpdate_SamplingRateBoost_samplingRateBoost_MaxRate = null;
            if (cmdletContext.SamplingRateBoost_MaxRate != null)
            {
                requestSamplingRuleUpdate_samplingRuleUpdate_SamplingRateBoost_samplingRateBoost_MaxRate = cmdletContext.SamplingRateBoost_MaxRate.Value;
            }
            if (requestSamplingRuleUpdate_samplingRuleUpdate_SamplingRateBoost_samplingRateBoost_MaxRate != null)
            {
                requestSamplingRuleUpdate_samplingRuleUpdate_SamplingRateBoost.MaxRate = requestSamplingRuleUpdate_samplingRuleUpdate_SamplingRateBoost_samplingRateBoost_MaxRate.Value;
                requestSamplingRuleUpdate_samplingRuleUpdate_SamplingRateBoostIsNull = false;
            }
             // determine if requestSamplingRuleUpdate_samplingRuleUpdate_SamplingRateBoost should be set to null
            if (requestSamplingRuleUpdate_samplingRuleUpdate_SamplingRateBoostIsNull)
            {
                requestSamplingRuleUpdate_samplingRuleUpdate_SamplingRateBoost = null;
            }
            if (requestSamplingRuleUpdate_samplingRuleUpdate_SamplingRateBoost != null)
            {
                request.SamplingRuleUpdate.SamplingRateBoost = requestSamplingRuleUpdate_samplingRuleUpdate_SamplingRateBoost;
                requestSamplingRuleUpdateIsNull = false;
            }
             // determine if request.SamplingRuleUpdate should be set to null
            if (requestSamplingRuleUpdateIsNull)
            {
                request.SamplingRuleUpdate = null;
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
        
        private Amazon.XRay.Model.UpdateSamplingRuleResponse CallAWSServiceOperation(IAmazonXRay client, Amazon.XRay.Model.UpdateSamplingRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS X-Ray", "UpdateSamplingRule");
            try
            {
                #if DESKTOP
                return client.UpdateSamplingRule(request);
                #elif CORECLR
                return client.UpdateSamplingRuleAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> SamplingRuleUpdate_Attribute { get; set; }
            public System.Double? SamplingRuleUpdate_FixedRate { get; set; }
            public System.String SamplingRuleUpdate_Host { get; set; }
            public System.String SamplingRuleUpdate_HTTPMethod { get; set; }
            public System.Int32? SamplingRuleUpdate_Priority { get; set; }
            public System.Int32? SamplingRuleUpdate_ReservoirSize { get; set; }
            public System.String SamplingRuleUpdate_ResourceARN { get; set; }
            public System.String SamplingRuleUpdate_RuleARN { get; set; }
            public System.String SamplingRuleUpdate_RuleName { get; set; }
            public System.Int32? SamplingRateBoost_CooldownWindowMinute { get; set; }
            public System.Double? SamplingRateBoost_MaxRate { get; set; }
            public System.String SamplingRuleUpdate_ServiceName { get; set; }
            public System.String SamplingRuleUpdate_ServiceType { get; set; }
            public System.String SamplingRuleUpdate_URLPath { get; set; }
            public System.Func<Amazon.XRay.Model.UpdateSamplingRuleResponse, UpdateXRSamplingRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SamplingRuleRecord;
        }
        
    }
}
