/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.OpsWorksCM;
using Amazon.OpsWorksCM.Model;

namespace Amazon.PowerShell.Cmdlets.OWCM
{
    /// <summary>
    /// Restores a backup to a server that is in a <code>CONNECTION_LOST</code>, <code>HEALTHY</code>,
    /// <code>RUNNING</code>, <code>UNHEALTHY</code>, or <code>TERMINATED</code> state. When
    /// you run RestoreServer, the server's EC2 instance is deleted, and a new EC2 instance
    /// is configured. RestoreServer maintains the existing server endpoint, so configuration
    /// management of the server's client devices (nodes) should continue to work. 
    /// 
    ///  
    /// <para>
    ///  This operation is asynchronous. 
    /// </para><para>
    ///  An <code>InvalidStateException</code> is thrown when the server is not in a valid
    /// state. A <code>ResourceNotFoundException</code> is thrown when the server does not
    /// exist. A <code>ValidationException</code> is raised when parameters of the request
    /// are not valid. 
    /// </para>
    /// </summary>
    [Cmdlet("Restore", "OWCMServer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS OpsWorksCM RestoreServer API operation.", Operation = new[] {"RestoreServer"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ServerName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.OpsWorksCM.Model.RestoreServerResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RestoreOWCMServerCmdlet : AmazonOpsWorksCMClientCmdlet, IExecutor
    {
        
        #region Parameter BackupId
        /// <summary>
        /// <para>
        /// <para> The ID of the backup that you want to use to restore a server. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BackupId { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para> The type of the instance to create. Valid values must be specified in the following
        /// format: <code>^([cm][34]|t2).*</code> For example, <code>m4.large</code>. Valid values
        /// are <code>t2.medium</code>, <code>m4.large</code>, and <code>m4.2xlarge</code>. If
        /// you do not specify this parameter, RestoreServer uses the instance type from the specified
        /// backup. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter KeyPair
        /// <summary>
        /// <para>
        /// <para> The name of the key pair to set on the new EC2 instance. This can be helpful if the
        /// administrator no longer has the SSH key. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KeyPair { get; set; }
        #endregion
        
        #region Parameter ServerName
        /// <summary>
        /// <para>
        /// <para> The name of the server that you want to restore. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ServerName { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ServerName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ServerName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-OWCMServer (RestoreServer)"))
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
            
            context.BackupId = this.BackupId;
            context.InstanceType = this.InstanceType;
            context.KeyPair = this.KeyPair;
            context.ServerName = this.ServerName;
            
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
            var request = new Amazon.OpsWorksCM.Model.RestoreServerRequest();
            
            if (cmdletContext.BackupId != null)
            {
                request.BackupId = cmdletContext.BackupId;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.KeyPair != null)
            {
                request.KeyPair = cmdletContext.KeyPair;
            }
            if (cmdletContext.ServerName != null)
            {
                request.ServerName = cmdletContext.ServerName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.ServerName;
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
        
        private Amazon.OpsWorksCM.Model.RestoreServerResponse CallAWSServiceOperation(IAmazonOpsWorksCM client, Amazon.OpsWorksCM.Model.RestoreServerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorksCM", "RestoreServer");
            try
            {
                #if DESKTOP
                return client.RestoreServer(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RestoreServerAsync(request);
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
            public System.String BackupId { get; set; }
            public System.String InstanceType { get; set; }
            public System.String KeyPair { get; set; }
            public System.String ServerName { get; set; }
        }
        
    }
}
