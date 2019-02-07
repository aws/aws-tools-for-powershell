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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Adds permissions to the resource-based policy of a version of an <a href="https://docs.aws.amazon.com/lambda/latest/dg/configuration-layers.html">AWS
    /// Lambda layer</a>. Use this action to grant layer usage permission to other accounts.
    /// You can grant permission to a single account, all AWS accounts, or all accounts in
    /// an organization.
    /// 
    ///  
    /// <para>
    /// To revoke permission, call <a>RemoveLayerVersionPermission</a> with the statement
    /// ID that you specified when you added it.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "LMLayerVersionPermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.AddLayerVersionPermissionResponse")]
    [AWSCmdlet("Calls the AWS Lambda AddLayerVersionPermission API operation.", Operation = new[] {"AddLayerVersionPermission"})]
    [AWSCmdletOutput("Amazon.Lambda.Model.AddLayerVersionPermissionResponse",
        "This cmdlet returns a Amazon.Lambda.Model.AddLayerVersionPermissionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddLMLayerVersionPermissionCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The API action that grants access to the layer. For example, <code>lambda:GetLayerVersion</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Action { get; set; }
        #endregion
        
        #region Parameter LayerName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the layer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String LayerName { get; set; }
        #endregion
        
        #region Parameter OrganizationId
        /// <summary>
        /// <para>
        /// <para>With the principal set to <code>*</code>, grant permission to all accounts in the
        /// specified organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OrganizationId { get; set; }
        #endregion
        
        #region Parameter Principal
        /// <summary>
        /// <para>
        /// <para>An account ID, or <code>*</code> to grant permission to all AWS accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Principal { get; set; }
        #endregion
        
        #region Parameter RevisionId
        /// <summary>
        /// <para>
        /// <para>Only update the policy if the revision ID matches the ID specified. Use this option
        /// to avoid modifying a policy that has changed since you last read it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RevisionId { get; set; }
        #endregion
        
        #region Parameter StatementId
        /// <summary>
        /// <para>
        /// <para>An identifier that distinguishes the policy from others on the same layer version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StatementId { get; set; }
        #endregion
        
        #region Parameter VersionNumber
        /// <summary>
        /// <para>
        /// <para>The version number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 VersionNumber { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LayerName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-LMLayerVersionPermission (AddLayerVersionPermission)"))
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
            
            context.Action = this.Action;
            context.LayerName = this.LayerName;
            context.OrganizationId = this.OrganizationId;
            context.Principal = this.Principal;
            context.RevisionId = this.RevisionId;
            context.StatementId = this.StatementId;
            if (ParameterWasBound("VersionNumber"))
                context.VersionNumber = this.VersionNumber;
            
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
            var request = new Amazon.Lambda.Model.AddLayerVersionPermissionRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Action = cmdletContext.Action;
            }
            if (cmdletContext.LayerName != null)
            {
                request.LayerName = cmdletContext.LayerName;
            }
            if (cmdletContext.OrganizationId != null)
            {
                request.OrganizationId = cmdletContext.OrganizationId;
            }
            if (cmdletContext.Principal != null)
            {
                request.Principal = cmdletContext.Principal;
            }
            if (cmdletContext.RevisionId != null)
            {
                request.RevisionId = cmdletContext.RevisionId;
            }
            if (cmdletContext.StatementId != null)
            {
                request.StatementId = cmdletContext.StatementId;
            }
            if (cmdletContext.VersionNumber != null)
            {
                request.VersionNumber = cmdletContext.VersionNumber.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.Lambda.Model.AddLayerVersionPermissionResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.AddLayerVersionPermissionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "AddLayerVersionPermission");
            try
            {
                #if DESKTOP
                return client.AddLayerVersionPermission(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.AddLayerVersionPermissionAsync(request);
                return task.Result;
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
            public System.String Action { get; set; }
            public System.String LayerName { get; set; }
            public System.String OrganizationId { get; set; }
            public System.String Principal { get; set; }
            public System.String RevisionId { get; set; }
            public System.String StatementId { get; set; }
            public System.Int64? VersionNumber { get; set; }
        }
        
    }
}
