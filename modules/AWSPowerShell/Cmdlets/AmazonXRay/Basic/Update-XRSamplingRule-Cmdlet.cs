/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Calls the AWS X-Ray UpdateSamplingRule API operation.", Operation = new[] {"UpdateSamplingRule"})]
    [AWSCmdletOutput("Amazon.XRay.Model.SamplingRuleRecord",
        "This cmdlet returns a SamplingRuleRecord object.",
        "The service call response (type Amazon.XRay.Model.UpdateSamplingRuleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateXRSamplingRuleCmdlet : AmazonXRayClientCmdlet, IExecutor
    {
        
        #region Parameter SamplingRuleUpdate_Attribute
        /// <summary>
        /// <para>
        /// <para>Matches attributes derived from the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SamplingRuleUpdate_Attributes")]
        public System.Collections.Hashtable SamplingRuleUpdate_Attribute { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_FixedRate
        /// <summary>
        /// <para>
        /// <para>The percentage of matching requests to instrument, after the reservoir is exhausted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double SamplingRuleUpdate_FixedRate { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_Host
        /// <summary>
        /// <para>
        /// <para>Matches the hostname from a request URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SamplingRuleUpdate_Host { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_HTTPMethod
        /// <summary>
        /// <para>
        /// <para>Matches the HTTP method of a request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SamplingRuleUpdate_HTTPMethod { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_Priority
        /// <summary>
        /// <para>
        /// <para>The priority of the sampling rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 SamplingRuleUpdate_Priority { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_ReservoirSize
        /// <summary>
        /// <para>
        /// <para>A fixed number of matching requests to instrument per second, prior to applying the
        /// fixed rate. The reservoir is not used directly by services, but applies to all services
        /// using the rule collectively.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 SamplingRuleUpdate_ReservoirSize { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_ResourceARN
        /// <summary>
        /// <para>
        /// <para>Matches the ARN of the AWS resource on which the service runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SamplingRuleUpdate_ResourceARN { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_RuleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the sampling rule. Specify a rule by either name or ARN, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SamplingRuleUpdate_RuleARN { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_RuleName
        /// <summary>
        /// <para>
        /// <para>The name of the sampling rule. Specify a rule by either name or ARN, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SamplingRuleUpdate_RuleName { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_ServiceName
        /// <summary>
        /// <para>
        /// <para>Matches the <code>name</code> that the service uses to identify itself in segments.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SamplingRuleUpdate_ServiceName { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_ServiceType
        /// <summary>
        /// <para>
        /// <para>Matches the <code>origin</code> that the service uses to identify its type in segments.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SamplingRuleUpdate_ServiceType { get; set; }
        #endregion
        
        #region Parameter SamplingRuleUpdate_URLPath
        /// <summary>
        /// <para>
        /// <para>Matches the path from a request URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SamplingRuleUpdate_URLPath { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-XRSamplingRule (UpdateSamplingRule)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.SamplingRuleUpdate_Attribute != null)
            {
                context.SamplingRuleUpdate_Attributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SamplingRuleUpdate_Attribute.Keys)
                {
                    context.SamplingRuleUpdate_Attributes.Add((String)hashKey, (String)(this.SamplingRuleUpdate_Attribute[hashKey]));
                }
            }
            if (ParameterWasBound("SamplingRuleUpdate_FixedRate"))
                context.SamplingRuleUpdate_FixedRate = this.SamplingRuleUpdate_FixedRate;
            context.SamplingRuleUpdate_Host = this.SamplingRuleUpdate_Host;
            context.SamplingRuleUpdate_HTTPMethod = this.SamplingRuleUpdate_HTTPMethod;
            if (ParameterWasBound("SamplingRuleUpdate_Priority"))
                context.SamplingRuleUpdate_Priority = this.SamplingRuleUpdate_Priority;
            if (ParameterWasBound("SamplingRuleUpdate_ReservoirSize"))
                context.SamplingRuleUpdate_ReservoirSize = this.SamplingRuleUpdate_ReservoirSize;
            context.SamplingRuleUpdate_ResourceARN = this.SamplingRuleUpdate_ResourceARN;
            context.SamplingRuleUpdate_RuleARN = this.SamplingRuleUpdate_RuleARN;
            context.SamplingRuleUpdate_RuleName = this.SamplingRuleUpdate_RuleName;
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
            bool requestSamplingRuleUpdateIsNull = true;
            request.SamplingRuleUpdate = new Amazon.XRay.Model.SamplingRuleUpdate();
            Dictionary<System.String, System.String> requestSamplingRuleUpdate_samplingRuleUpdate_Attribute = null;
            if (cmdletContext.SamplingRuleUpdate_Attributes != null)
            {
                requestSamplingRuleUpdate_samplingRuleUpdate_Attribute = cmdletContext.SamplingRuleUpdate_Attributes;
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
             // determine if request.SamplingRuleUpdate should be set to null
            if (requestSamplingRuleUpdateIsNull)
            {
                request.SamplingRuleUpdate = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.SamplingRuleRecord;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            public Dictionary<System.String, System.String> SamplingRuleUpdate_Attributes { get; set; }
            public System.Double? SamplingRuleUpdate_FixedRate { get; set; }
            public System.String SamplingRuleUpdate_Host { get; set; }
            public System.String SamplingRuleUpdate_HTTPMethod { get; set; }
            public System.Int32? SamplingRuleUpdate_Priority { get; set; }
            public System.Int32? SamplingRuleUpdate_ReservoirSize { get; set; }
            public System.String SamplingRuleUpdate_ResourceARN { get; set; }
            public System.String SamplingRuleUpdate_RuleARN { get; set; }
            public System.String SamplingRuleUpdate_RuleName { get; set; }
            public System.String SamplingRuleUpdate_ServiceName { get; set; }
            public System.String SamplingRuleUpdate_ServiceType { get; set; }
            public System.String SamplingRuleUpdate_URLPath { get; set; }
        }
        
    }
}
