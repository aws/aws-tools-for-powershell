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
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Deletes the specified mount target.
    /// 
    ///  
    /// <para>
    /// This operation forcibly breaks any mounts of the file system by using the mount target
    /// that is being deleted, which might disrupt instances or applications using those mounts.
    /// To avoid applications getting cut off abruptly, you might consider unmounting any
    /// mounts of the mount target, if feasible. The operation also deletes the associated
    /// network interface. Uncommitted writes might be lost, but breaking a mount target using
    /// this operation does not corrupt the file system itself. The file system you created
    /// remains. You can mount an EC2 instance in your VPC by using another mount target.
    /// </para><para>
    /// This operation requires permissions for the following action on the file system:
    /// </para><ul><li><para><code>elasticfilesystem:DeleteMountTarget</code></para></li></ul><note><para>
    /// The <code>DeleteMountTarget</code> call returns while the mount target state is still
    /// <code>deleting</code>. You can check the mount target deletion by calling the <a>DescribeMountTargets</a>
    /// operation, which returns a list of mount target descriptions for the given file system.
    /// 
    /// </para></note><para>
    /// The operation also requires permissions for the following Amazon EC2 action on the
    /// mount target's network interface:
    /// </para><ul><li><para><code>ec2:DeleteNetworkInterface</code></para></li></ul>
    /// </summary>
    [Cmdlet("Remove", "EFSMountTarget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Elastic File System DeleteMountTarget API operation.", Operation = new[] {"DeleteMountTarget"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the MountTargetId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.ElasticFileSystem.Model.DeleteMountTargetResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveEFSMountTargetCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        #region Parameter MountTargetId
        /// <summary>
        /// <para>
        /// <para>The ID of the mount target to delete (String).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String MountTargetId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the MountTargetId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("MountTargetId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EFSMountTarget (DeleteMountTarget)"))
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
            
            context.MountTargetId = this.MountTargetId;
            
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
            var request = new Amazon.ElasticFileSystem.Model.DeleteMountTargetRequest();
            
            if (cmdletContext.MountTargetId != null)
            {
                request.MountTargetId = cmdletContext.MountTargetId;
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
                    pipelineOutput = this.MountTargetId;
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
        
        private Amazon.ElasticFileSystem.Model.DeleteMountTargetResponse CallAWSServiceOperation(IAmazonElasticFileSystem client, Amazon.ElasticFileSystem.Model.DeleteMountTargetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic File System", "DeleteMountTarget");
            try
            {
                #if DESKTOP
                return client.DeleteMountTarget(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteMountTargetAsync(request);
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
            public System.String MountTargetId { get; set; }
        }
        
    }
}
