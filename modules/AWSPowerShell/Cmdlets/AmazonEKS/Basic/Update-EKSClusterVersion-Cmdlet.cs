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
using Amazon.EKS;
using Amazon.EKS.Model;

namespace Amazon.PowerShell.Cmdlets.EKS
{
    /// <summary>
    /// Updates an Amazon EKS cluster to the specified Kubernetes version. Your cluster continues
    /// to function during the update. The response output includes an update ID that you
    /// can use to track the status of your cluster update with the <a>DescribeUpdate</a>
    /// API operation.
    /// 
    ///  
    /// <para>
    /// Cluster updates are asynchronous, and they should finish within a few minutes. During
    /// an update, the cluster status moves to <code>UPDATING</code> (this status transition
    /// is eventually consistent). When the update is complete (either <code>Failed</code>
    /// or <code>Successful</code>), the cluster status moves to <code>Active</code>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "EKSClusterVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EKS.Model.Update")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes UpdateClusterVersion API operation.", Operation = new[] {"UpdateClusterVersion"})]
    [AWSCmdletOutput("Amazon.EKS.Model.Update",
        "This cmdlet returns a Update object.",
        "The service call response (type Amazon.EKS.Model.UpdateClusterVersionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateEKSClusterVersionCmdlet : AmazonEKSClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon EKS cluster to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>The desired Kubernetes version following a successful update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Version { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EKSClusterVersion (UpdateClusterVersion)"))
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
            
            context.ClientRequestToken = this.ClientRequestToken;
            context.Name = this.Name;
            context.Version = this.Version;
            
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
            var request = new Amazon.EKS.Model.UpdateClusterVersionRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Version != null)
            {
                request.Version = cmdletContext.Version;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Update;
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
        
        private Amazon.EKS.Model.UpdateClusterVersionResponse CallAWSServiceOperation(IAmazonEKS client, Amazon.EKS.Model.UpdateClusterVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "UpdateClusterVersion");
            try
            {
                #if DESKTOP
                return client.UpdateClusterVersion(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateClusterVersionAsync(request);
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
            public System.String ClientRequestToken { get; set; }
            public System.String Name { get; set; }
            public System.String Version { get; set; }
        }
        
    }
}
