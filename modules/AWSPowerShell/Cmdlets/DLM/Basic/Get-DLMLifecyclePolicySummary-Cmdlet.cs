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
    [AWSCmdlet("Calls the Amazon Data Lifecycle Manager GetLifecyclePolicies API operation.", Operation = new[] {"GetLifecyclePolicies"}, SelectReturnType = typeof(Amazon.DLM.Model.GetLifecyclePoliciesResponse))]
    [AWSCmdletOutput("Amazon.DLM.Model.LifecyclePolicySummary or Amazon.DLM.Model.GetLifecyclePoliciesResponse",
        "This cmdlet returns a collection of Amazon.DLM.Model.LifecyclePolicySummary objects.",
        "The service call response (type Amazon.DLM.Model.GetLifecyclePoliciesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDLMLifecyclePolicySummaryCmdlet : AmazonDLMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PolicyId
        /// <summary>
        /// <para>
        /// <para>The identifiers of the data lifecycle policies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyIds")]
        public System.String[] PolicyId { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The resource type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceTypes")]
        public System.String[] ResourceType { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The activation state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DLM.GettablePolicyStateValues")]
        public Amazon.DLM.GettablePolicyStateValues State { get; set; }
        #endregion
        
        #region Parameter TagsToAdd
        /// <summary>
        /// <para>
        /// <para>The tags to add to objects created by the policy.</para><para>Tags are strings in the format <code>key=value</code>.</para><para>These user-defined tags are added in addition to the Amazon Web Services-added lifecycle
        /// tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] TagsToAdd { get; set; }
        #endregion
        
        #region Parameter TargetTag
        /// <summary>
        /// <para>
        /// <para>The target tag for a policy.</para><para>Tags are strings in the format <code>key=value</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTags")]
        public System.String[] TargetTag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Policies'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DLM.Model.GetLifecyclePoliciesResponse).
        /// Specifying the name of a property of type Amazon.DLM.Model.GetLifecyclePoliciesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Policies";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DLM.Model.GetLifecyclePoliciesResponse, GetDLMLifecyclePolicySummaryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.PolicyId != null)
            {
                context.PolicyId = new List<System.String>(this.PolicyId);
            }
            if (this.ResourceType != null)
            {
                context.ResourceType = new List<System.String>(this.ResourceType);
            }
            context.State = this.State;
            if (this.TagsToAdd != null)
            {
                context.TagsToAdd = new List<System.String>(this.TagsToAdd);
            }
            if (this.TargetTag != null)
            {
                context.TargetTag = new List<System.String>(this.TargetTag);
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
            
            if (cmdletContext.PolicyId != null)
            {
                request.PolicyIds = cmdletContext.PolicyId;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceTypes = cmdletContext.ResourceType;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
            }
            if (cmdletContext.TagsToAdd != null)
            {
                request.TagsToAdd = cmdletContext.TagsToAdd;
            }
            if (cmdletContext.TargetTag != null)
            {
                request.TargetTags = cmdletContext.TargetTag;
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
            public List<System.String> PolicyId { get; set; }
            public List<System.String> ResourceType { get; set; }
            public Amazon.DLM.GettablePolicyStateValues State { get; set; }
            public List<System.String> TagsToAdd { get; set; }
            public List<System.String> TargetTag { get; set; }
            public System.Func<Amazon.DLM.Model.GetLifecyclePoliciesResponse, GetDLMLifecyclePolicySummaryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Policies;
        }
        
    }
}
