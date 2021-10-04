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
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Enables lifecycle management by creating a new <code>LifecycleConfiguration</code>
    /// object. A <code>LifecycleConfiguration</code> object defines when files in an Amazon
    /// EFS file system are automatically transitioned to the lower-cost EFS Infrequent Access
    /// (IA) storage class. To enable EFS Intelligent Tiering, set the value of <code>TransitionToPrimaryStorageClass</code>
    /// to <code>AFTER_1_ACCESS</code>. For more information, see <a href="https://docs.aws.amazon.com/efs/latest/ug/lifecycle-management-efs.html">EFS
    /// Lifecycle Management</a>.
    /// 
    ///  
    /// <para>
    /// Each Amazon EFS file system supports one lifecycle configuration, which applies to
    /// all files in the file system. If a <code>LifecycleConfiguration</code> object already
    /// exists for the specified file system, a <code>PutLifecycleConfiguration</code> call
    /// modifies the existing configuration. A <code>PutLifecycleConfiguration</code> call
    /// with an empty <code>LifecyclePolicies</code> array in the request body deletes any
    /// existing <code>LifecycleConfiguration</code> and turns off lifecycle management for
    /// the file system.
    /// </para><para>
    /// In the request, specify the following: 
    /// </para><ul><li><para>
    /// The ID for the file system for which you are enabling, disabling, or modifying lifecycle
    /// management.
    /// </para></li><li><para>
    /// A <code>LifecyclePolicies</code> array of <code>LifecyclePolicy</code> objects that
    /// define when files are moved to the IA storage class. Amazon EFS requires that each
    /// <code>LifecyclePolicy</code> object have only have a single transition, so the <code>LifecyclePolicies</code>
    /// array needs to be structured with separate <code>LifecyclePolicy</code> objects. See
    /// the example requests in the following section for more information.
    /// </para></li></ul><para>
    /// This operation requires permissions for the <code>elasticfilesystem:PutLifecycleConfiguration</code>
    /// operation.
    /// </para><para>
    /// To apply a <code>LifecycleConfiguration</code> object to an encrypted file system,
    /// you need the same Key Management Service permissions as when you created the encrypted
    /// file system. 
    /// </para>
    /// </summary>
    [Cmdlet("Write", "EFSLifecycleConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticFileSystem.Model.LifecyclePolicy")]
    [AWSCmdlet("Calls the Amazon Elastic File System PutLifecycleConfiguration API operation.", Operation = new[] {"PutLifecycleConfiguration"}, SelectReturnType = typeof(Amazon.ElasticFileSystem.Model.PutLifecycleConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ElasticFileSystem.Model.LifecyclePolicy or Amazon.ElasticFileSystem.Model.PutLifecycleConfigurationResponse",
        "This cmdlet returns a collection of Amazon.ElasticFileSystem.Model.LifecyclePolicy objects.",
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
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FileSystemId { get; set; }
        #endregion
        
        #region Parameter LifecyclePolicy
        /// <summary>
        /// <para>
        /// <para>An array of <code>LifecyclePolicy</code> objects that define the file system's <code>LifecycleConfiguration</code>
        /// object. A <code>LifecycleConfiguration</code> object informs EFS lifecycle management
        /// and intelligent tiering of the following:</para><ul><li><para>When to move files in the file system from primary storage to the IA storage class.</para></li><li><para>When to move files that are in IA storage to primary storage.</para></li></ul><note><para>When using the <code>put-lifecycle-configuration</code> CLI command or the <code>PutLifecycleConfiguration</code>
        /// API action, Amazon EFS requires that each <code>LifecyclePolicy</code> object have
        /// only a single transition. This means that in a request body, <code>LifecyclePolicies</code>
        /// needs to be structured as an array of <code>LifecyclePolicy</code> objects, one object
        /// for each transition, <code>TransitionToIA</code>, <code>TransitionToPrimaryStorageClass</code>.
        /// See the example requests in the following section for more information.</para></note>
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
        [Alias("LifecyclePolicies")]
        public Amazon.ElasticFileSystem.Model.LifecyclePolicy[] LifecyclePolicy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LifecyclePolicies'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticFileSystem.Model.PutLifecycleConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ElasticFileSystem.Model.PutLifecycleConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LifecyclePolicies";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FileSystemId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FileSystemId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FileSystemId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FileSystemId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EFSLifecycleConfiguration (PutLifecycleConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticFileSystem.Model.PutLifecycleConfigurationResponse, WriteEFSLifecycleConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FileSystemId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FileSystemId = this.FileSystemId;
            #if MODULAR
            if (this.FileSystemId == null && ParameterWasBound(nameof(this.FileSystemId)))
            {
                WriteWarning("You are passing $null as a value for parameter FileSystemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.LifecyclePolicy != null)
            {
                context.LifecyclePolicy = new List<Amazon.ElasticFileSystem.Model.LifecyclePolicy>(this.LifecyclePolicy);
            }
            #if MODULAR
            if (this.LifecyclePolicy == null && ParameterWasBound(nameof(this.LifecyclePolicy)))
            {
                WriteWarning("You are passing $null as a value for parameter LifecyclePolicy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            if (cmdletContext.LifecyclePolicy != null)
            {
                request.LifecyclePolicies = cmdletContext.LifecyclePolicy;
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
        
        private Amazon.ElasticFileSystem.Model.PutLifecycleConfigurationResponse CallAWSServiceOperation(IAmazonElasticFileSystem client, Amazon.ElasticFileSystem.Model.PutLifecycleConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic File System", "PutLifecycleConfiguration");
            try
            {
                #if DESKTOP
                return client.PutLifecycleConfiguration(request);
                #elif CORECLR
                return client.PutLifecycleConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ElasticFileSystem.Model.LifecyclePolicy> LifecyclePolicy { get; set; }
            public System.Func<Amazon.ElasticFileSystem.Model.PutLifecycleConfigurationResponse, WriteEFSLifecycleConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LifecyclePolicies;
        }
        
    }
}
