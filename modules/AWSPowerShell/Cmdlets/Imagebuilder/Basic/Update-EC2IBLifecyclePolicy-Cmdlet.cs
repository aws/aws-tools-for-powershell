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
using Amazon.Imagebuilder;
using Amazon.Imagebuilder.Model;

namespace Amazon.PowerShell.Cmdlets.EC2IB
{
    /// <summary>
    /// Update the specified lifecycle policy.
    /// </summary>
    [Cmdlet("Update", "EC2IBLifecyclePolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the EC2 Image Builder UpdateLifecyclePolicy API operation.", Operation = new[] {"UpdateLifecyclePolicy"}, SelectReturnType = typeof(Amazon.Imagebuilder.Model.UpdateLifecyclePolicyResponse))]
    [AWSCmdletOutput("System.String or Amazon.Imagebuilder.Model.UpdateLifecyclePolicyResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Imagebuilder.Model.UpdateLifecyclePolicyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateEC2IBLifecyclePolicyCmdlet : AmazonImagebuilderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Optional description for the lifecycle policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ExecutionRole
        /// <summary>
        /// <para>
        /// <para>The name of the IAM role that Image Builder should use to update the lifecycle policy.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ExecutionRole { get; set; }
        #endregion
        
        #region Parameter LifecyclePolicyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the lifecycle policy resource.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String LifecyclePolicyArn { get; set; }
        #endregion
        
        #region Parameter PolicyDetail
        /// <summary>
        /// <para>
        /// <para>The configuration details for a lifecycle policy resource.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("PolicyDetails")]
        public Amazon.Imagebuilder.Model.LifecyclePolicyDetail[] PolicyDetail { get; set; }
        #endregion
        
        #region Parameter ResourceSelection_Recipe
        /// <summary>
        /// <para>
        /// <para>A list of recipes that are used as selection criteria for the output images that the
        /// lifecycle policy applies to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSelection_Recipes")]
        public Amazon.Imagebuilder.Model.LifecyclePolicyResourceSelectionRecipe[] ResourceSelection_Recipe { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The type of image resource that the lifecycle policy applies to.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Imagebuilder.LifecyclePolicyResourceType")]
        public Amazon.Imagebuilder.LifecyclePolicyResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Indicates whether the lifecycle policy resource is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Imagebuilder.LifecyclePolicyStatus")]
        public Amazon.Imagebuilder.LifecyclePolicyStatus Status { get; set; }
        #endregion
        
        #region Parameter ResourceSelection_TagMap
        /// <summary>
        /// <para>
        /// <para>A list of tags that are used as selection criteria for the resources that the lifecycle
        /// policy applies to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ResourceSelection_TagMap { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure idempotency of the request.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a> in the <i>Amazon EC2 API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LifecyclePolicyArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Imagebuilder.Model.UpdateLifecyclePolicyResponse).
        /// Specifying the name of a property of type Amazon.Imagebuilder.Model.UpdateLifecyclePolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LifecyclePolicyArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LifecyclePolicyArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EC2IBLifecyclePolicy (UpdateLifecyclePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Imagebuilder.Model.UpdateLifecyclePolicyResponse, UpdateEC2IBLifecyclePolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.ExecutionRole = this.ExecutionRole;
            #if MODULAR
            if (this.ExecutionRole == null && ParameterWasBound(nameof(this.ExecutionRole)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionRole which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LifecyclePolicyArn = this.LifecyclePolicyArn;
            #if MODULAR
            if (this.LifecyclePolicyArn == null && ParameterWasBound(nameof(this.LifecyclePolicyArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LifecyclePolicyArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PolicyDetail != null)
            {
                context.PolicyDetail = new List<Amazon.Imagebuilder.Model.LifecyclePolicyDetail>(this.PolicyDetail);
            }
            #if MODULAR
            if (this.PolicyDetail == null && ParameterWasBound(nameof(this.PolicyDetail)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyDetail which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ResourceSelection_Recipe != null)
            {
                context.ResourceSelection_Recipe = new List<Amazon.Imagebuilder.Model.LifecyclePolicyResourceSelectionRecipe>(this.ResourceSelection_Recipe);
            }
            if (this.ResourceSelection_TagMap != null)
            {
                context.ResourceSelection_TagMap = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ResourceSelection_TagMap.Keys)
                {
                    context.ResourceSelection_TagMap.Add((String)hashKey, (String)(this.ResourceSelection_TagMap[hashKey]));
                }
            }
            context.ResourceType = this.ResourceType;
            #if MODULAR
            if (this.ResourceType == null && ParameterWasBound(nameof(this.ResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Status = this.Status;
            
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
            var request = new Amazon.Imagebuilder.Model.UpdateLifecyclePolicyRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExecutionRole != null)
            {
                request.ExecutionRole = cmdletContext.ExecutionRole;
            }
            if (cmdletContext.LifecyclePolicyArn != null)
            {
                request.LifecyclePolicyArn = cmdletContext.LifecyclePolicyArn;
            }
            if (cmdletContext.PolicyDetail != null)
            {
                request.PolicyDetails = cmdletContext.PolicyDetail;
            }
            
             // populate ResourceSelection
            var requestResourceSelectionIsNull = true;
            request.ResourceSelection = new Amazon.Imagebuilder.Model.LifecyclePolicyResourceSelection();
            List<Amazon.Imagebuilder.Model.LifecyclePolicyResourceSelectionRecipe> requestResourceSelection_resourceSelection_Recipe = null;
            if (cmdletContext.ResourceSelection_Recipe != null)
            {
                requestResourceSelection_resourceSelection_Recipe = cmdletContext.ResourceSelection_Recipe;
            }
            if (requestResourceSelection_resourceSelection_Recipe != null)
            {
                request.ResourceSelection.Recipes = requestResourceSelection_resourceSelection_Recipe;
                requestResourceSelectionIsNull = false;
            }
            Dictionary<System.String, System.String> requestResourceSelection_resourceSelection_TagMap = null;
            if (cmdletContext.ResourceSelection_TagMap != null)
            {
                requestResourceSelection_resourceSelection_TagMap = cmdletContext.ResourceSelection_TagMap;
            }
            if (requestResourceSelection_resourceSelection_TagMap != null)
            {
                request.ResourceSelection.TagMap = requestResourceSelection_resourceSelection_TagMap;
                requestResourceSelectionIsNull = false;
            }
             // determine if request.ResourceSelection should be set to null
            if (requestResourceSelectionIsNull)
            {
                request.ResourceSelection = null;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.Imagebuilder.Model.UpdateLifecyclePolicyResponse CallAWSServiceOperation(IAmazonImagebuilder client, Amazon.Imagebuilder.Model.UpdateLifecyclePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "EC2 Image Builder", "UpdateLifecyclePolicy");
            try
            {
                #if DESKTOP
                return client.UpdateLifecyclePolicy(request);
                #elif CORECLR
                return client.UpdateLifecyclePolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String ExecutionRole { get; set; }
            public System.String LifecyclePolicyArn { get; set; }
            public List<Amazon.Imagebuilder.Model.LifecyclePolicyDetail> PolicyDetail { get; set; }
            public List<Amazon.Imagebuilder.Model.LifecyclePolicyResourceSelectionRecipe> ResourceSelection_Recipe { get; set; }
            public Dictionary<System.String, System.String> ResourceSelection_TagMap { get; set; }
            public Amazon.Imagebuilder.LifecyclePolicyResourceType ResourceType { get; set; }
            public Amazon.Imagebuilder.LifecyclePolicyStatus Status { get; set; }
            public System.Func<Amazon.Imagebuilder.Model.UpdateLifecyclePolicyResponse, UpdateEC2IBLifecyclePolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LifecyclePolicyArn;
        }
        
    }
}
