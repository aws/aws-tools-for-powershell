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
    /// Enables lifecycle management by creating a new <code>LifecycleConfiguration</code>
    /// object. A <code>LifecycleConfiguration</code> object defines when files in an Amazon
    /// EFS file system are automatically transitioned to the lower-cost EFS Infrequent Access
    /// (IA) storage class. A <code>LifecycleConfiguration</code> applies to all files in
    /// a file system.
    /// 
    ///  
    /// <para>
    /// Each Amazon EFS file system supports one lifecycle configuration, which applies to
    /// all files in the file system. If a <code>LifecycleConfiguration</code> object already
    /// exists for the specified file system, a <code>PutLifecycleConfiguration</code> call
    /// modifies the existing configuration. A <code>PutLifecycleConfiguration</code> call
    /// with an empty <code>LifecyclePolicies</code> array in the request body deletes any
    /// existing <code>LifecycleConfiguration</code> and disables lifecycle management.
    /// </para><note><para>
    /// You can enable lifecycle management only for EFS file systems created after the release
    /// of EFS infrequent access.
    /// </para></note><para>
    /// In the request, specify the following: 
    /// </para><ul><li><para>
    /// The ID for the file system for which you are creating a lifecycle management configuration.
    /// </para></li><li><para>
    /// A <code>LifecyclePolicies</code> array of <code>LifecyclePolicy</code> objects that
    /// define when files are moved to the IA storage class. The array can contain only one
    /// <code>"TransitionToIA": "AFTER_30_DAYS"</code><code>LifecyclePolicy</code> item.
    /// </para></li></ul><para>
    /// This operation requires permissions for the <code>elasticfilesystem:PutLifecycleConfiguration</code>
    /// operation.
    /// </para><para>
    /// To apply a <code>LifecycleConfiguration</code> object to an encrypted file system,
    /// you need the same AWS Key Management Service (AWS KMS) permissions as when you created
    /// the encrypted file system. 
    /// </para>
    /// </summary>
    [Cmdlet("Write", "EFSLifecycleConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticFileSystem.Model.LifecyclePolicy")]
    [AWSCmdlet("Calls the Amazon Elastic File System PutLifecycleConfiguration API operation.", Operation = new[] {"PutLifecycleConfiguration"})]
    [AWSCmdletOutput("Amazon.ElasticFileSystem.Model.LifecyclePolicy",
        "This cmdlet returns a collection of LifecyclePolicy objects.",
        "The service call response (type Amazon.ElasticFileSystem.Model.PutLifecycleConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteEFSLifecycleConfigurationCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// <para>The ID of the file system for which you are creating the <code>LifecycleConfiguration</code>
        /// object (String).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String FileSystemId { get; set; }
        #endregion
        
        #region Parameter LifecyclePolicy
        /// <summary>
        /// <para>
        /// <para>An array of <code>LifecyclePolicy</code> objects that define the file system's <code>LifecycleConfiguration</code>
        /// object. A <code>LifecycleConfiguration</code> object tells lifecycle management when
        /// to transition files from the Standard storage class to the Infrequent Access storage
        /// class.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LifecyclePolicies")]
        public Amazon.ElasticFileSystem.Model.LifecyclePolicy[] LifecyclePolicy { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FileSystemId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EFSLifecycleConfiguration (PutLifecycleConfiguration)"))
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
            
            context.FileSystemId = this.FileSystemId;
            if (this.LifecyclePolicy != null)
            {
                context.LifecyclePolicies = new List<Amazon.ElasticFileSystem.Model.LifecyclePolicy>(this.LifecyclePolicy);
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
            var request = new Amazon.ElasticFileSystem.Model.PutLifecycleConfigurationRequest();
            
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
            }
            if (cmdletContext.LifecyclePolicies != null)
            {
                request.LifecyclePolicies = cmdletContext.LifecyclePolicies;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.LifecyclePolicies;
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
        
        private Amazon.ElasticFileSystem.Model.PutLifecycleConfigurationResponse CallAWSServiceOperation(IAmazonElasticFileSystem client, Amazon.ElasticFileSystem.Model.PutLifecycleConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic File System", "PutLifecycleConfiguration");
            try
            {
                #if DESKTOP
                return client.PutLifecycleConfiguration(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutLifecycleConfigurationAsync(request);
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
            public System.String FileSystemId { get; set; }
            public List<Amazon.ElasticFileSystem.Model.LifecyclePolicy> LifecyclePolicies { get; set; }
        }
        
    }
}
