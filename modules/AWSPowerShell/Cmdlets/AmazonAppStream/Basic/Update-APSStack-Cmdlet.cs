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
using Amazon.AppStream;
using Amazon.AppStream.Model;

namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Updates the specified stack.
    /// </summary>
    [Cmdlet("Update", "APSStack", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.Stack")]
    [AWSCmdlet("Calls the AWS AppStream UpdateStack API operation.", Operation = new[] {"UpdateStack"})]
    [AWSCmdletOutput("Amazon.AppStream.Model.Stack",
        "This cmdlet returns a Stack object.",
        "The service call response (type Amazon.AppStream.Model.UpdateStackResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAPSStackCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        #region Parameter AttributesToDelete
        /// <summary>
        /// <para>
        /// <para>The stack attributes to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] AttributesToDelete { get; set; }
        #endregion
        
        #region Parameter DeleteStorageConnector
        /// <summary>
        /// <para>
        /// <para>Deletes the storage connectors currently enabled for the stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DeleteStorageConnectors")]
        public System.Boolean DeleteStorageConnector { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description for display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The stack name for display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RedirectURL
        /// <summary>
        /// <para>
        /// <para>The URL the user is redirected to after the streaming session ends.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RedirectURL { get; set; }
        #endregion
        
        #region Parameter StorageConnector
        /// <summary>
        /// <para>
        /// <para>The storage connectors to enable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StorageConnectors")]
        public Amazon.AppStream.Model.StorageConnector[] StorageConnector { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-APSStack (UpdateStack)"))
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
            
            if (this.AttributesToDelete != null)
            {
                context.AttributesToDelete = new List<System.String>(this.AttributesToDelete);
            }
            if (ParameterWasBound("DeleteStorageConnector"))
                context.DeleteStorageConnectors = this.DeleteStorageConnector;
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.Name = this.Name;
            context.RedirectURL = this.RedirectURL;
            if (this.StorageConnector != null)
            {
                context.StorageConnectors = new List<Amazon.AppStream.Model.StorageConnector>(this.StorageConnector);
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
            var request = new Amazon.AppStream.Model.UpdateStackRequest();
            
            if (cmdletContext.AttributesToDelete != null)
            {
                request.AttributesToDelete = cmdletContext.AttributesToDelete;
            }
            if (cmdletContext.DeleteStorageConnectors != null)
            {
                request.DeleteStorageConnectors = cmdletContext.DeleteStorageConnectors.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RedirectURL != null)
            {
                request.RedirectURL = cmdletContext.RedirectURL;
            }
            if (cmdletContext.StorageConnectors != null)
            {
                request.StorageConnectors = cmdletContext.StorageConnectors;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Stack;
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
        
        private Amazon.AppStream.Model.UpdateStackResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.UpdateStackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppStream", "UpdateStack");
            try
            {
                #if DESKTOP
                return client.UpdateStack(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateStackAsync(request);
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
            public List<System.String> AttributesToDelete { get; set; }
            public System.Boolean? DeleteStorageConnectors { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.String Name { get; set; }
            public System.String RedirectURL { get; set; }
            public List<Amazon.AppStream.Model.StorageConnector> StorageConnectors { get; set; }
        }
        
    }
}
