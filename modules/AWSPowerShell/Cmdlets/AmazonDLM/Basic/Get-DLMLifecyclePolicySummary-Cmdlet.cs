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
using Amazon.DLM;
using Amazon.DLM.Model;

namespace Amazon.PowerShell.Cmdlets.DLM
{
    /// <summary>
    /// Gets summary information about all or the specified data lifecycle policies.
    /// 
    ///  
    /// <para>
    /// To get complete information about a policy, use <a>GetLifecyclePolicy</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DLMLifecyclePolicySummary")]
    [OutputType("Amazon.DLM.Model.LifecyclePolicySummary")]
    [AWSCmdlet("Calls the Amazon Data Lifecycle Manager GetLifecyclePolicies API operation.", Operation = new[] {"GetLifecyclePolicies"})]
    [AWSCmdletOutput("Amazon.DLM.Model.LifecyclePolicySummary",
        "This cmdlet returns a collection of LifecyclePolicySummary objects.",
        "The service call response (type Amazon.DLM.Model.GetLifecyclePoliciesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDLMLifecyclePolicySummaryCmdlet : AmazonDLMClientCmdlet, IExecutor
    {
        
        #region Parameter PolicyId
        /// <summary>
        /// <para>
        /// <para>The identifiers of the data lifecycle policies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PolicyIds")]
        public System.String[] PolicyId { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The resource type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResourceTypes")]
        public System.String[] ResourceType { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The activation state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DLM.GettablePolicyStateValues")]
        public Amazon.DLM.GettablePolicyStateValues State { get; set; }
        #endregion
        
        #region Parameter TagsToAdd
        /// <summary>
        /// <para>
        /// <para>The tags to add to objects created by the policy.</para><para>Tags are strings in the format <code>key=value</code>.</para><para>These user-defined tags are added in addition to the AWS-added lifecycle tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] TagsToAdd { get; set; }
        #endregion
        
        #region Parameter TargetTag
        /// <summary>
        /// <para>
        /// <para>The target tag for a policy.</para><para>Tags are strings in the format <code>key=value</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetTags")]
        public System.String[] TargetTag { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.PolicyId != null)
            {
                context.PolicyIds = new List<System.String>(this.PolicyId);
            }
            if (this.ResourceType != null)
            {
                context.ResourceTypes = new List<System.String>(this.ResourceType);
            }
            context.State = this.State;
            if (this.TagsToAdd != null)
            {
                context.TagsToAdd = new List<System.String>(this.TagsToAdd);
            }
            if (this.TargetTag != null)
            {
                context.TargetTags = new List<System.String>(this.TargetTag);
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
            var request = new Amazon.DLM.Model.GetLifecyclePoliciesRequest();
            
            if (cmdletContext.PolicyIds != null)
            {
                request.PolicyIds = cmdletContext.PolicyIds;
            }
            if (cmdletContext.ResourceTypes != null)
            {
                request.ResourceTypes = cmdletContext.ResourceTypes;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
            }
            if (cmdletContext.TagsToAdd != null)
            {
                request.TagsToAdd = cmdletContext.TagsToAdd;
            }
            if (cmdletContext.TargetTags != null)
            {
                request.TargetTags = cmdletContext.TargetTags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Policies;
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
        
        private Amazon.DLM.Model.GetLifecyclePoliciesResponse CallAWSServiceOperation(IAmazonDLM client, Amazon.DLM.Model.GetLifecyclePoliciesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Data Lifecycle Manager", "GetLifecyclePolicies");
            try
            {
                #if DESKTOP
                return client.GetLifecyclePolicies(request);
                #elif CORECLR
                return client.GetLifecyclePoliciesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> PolicyIds { get; set; }
            public List<System.String> ResourceTypes { get; set; }
            public Amazon.DLM.GettablePolicyStateValues State { get; set; }
            public List<System.String> TagsToAdd { get; set; }
            public List<System.String> TargetTags { get; set; }
        }
        
    }
}
