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
using Amazon.FSx;
using Amazon.FSx.Model;

namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Updates the configuration of an existing data repository association on an Amazon
    /// FSx for Lustre file system. Data repository associations are supported only for file
    /// systems with the <code>Persistent_2</code> deployment type.
    /// </summary>
    [Cmdlet("Update", "FSXDataRepositoryAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.DataRepositoryAssociation")]
    [AWSCmdlet("Calls the Amazon FSx UpdateDataRepositoryAssociation API operation.", Operation = new[] {"UpdateDataRepositoryAssociation"}, SelectReturnType = typeof(Amazon.FSx.Model.UpdateDataRepositoryAssociationResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.DataRepositoryAssociation or Amazon.FSx.Model.UpdateDataRepositoryAssociationResponse",
        "This cmdlet returns an Amazon.FSx.Model.DataRepositoryAssociation object.",
        "The service call response (type Amazon.FSx.Model.UpdateDataRepositoryAssociationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateFSXDataRepositoryAssociationCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        #region Parameter AssociationId
        /// <summary>
        /// <para>
        /// <para>The ID of the data repository association that you are updating.</para>
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
        public System.String AssociationId { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter AutoExportPolicy_Event
        /// <summary>
        /// <para>
        /// <para>The <code>AutoExportPolicy</code> can have the following event values:</para><ul><li><para><code>NEW</code> - Amazon FSx automatically exports new files and directories to
        /// the data repository as they are added to the file system.</para></li><li><para><code>CHANGED</code> - Amazon FSx automatically exports changes to files and directories
        /// on the file system to the data repository.</para></li><li><para><code>DELETED</code> - Files and directories are automatically deleted on the data
        /// repository when they are deleted on the file system.</para></li></ul><para>You can define any combination of event types for your <code>AutoExportPolicy</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3_AutoExportPolicy_Events")]
        public System.String[] AutoExportPolicy_Event { get; set; }
        #endregion
        
        #region Parameter AutoImportPolicy_Event
        /// <summary>
        /// <para>
        /// <para>The <code>AutoImportPolicy</code> can have the following event values:</para><ul><li><para><code>NEW</code> - Amazon FSx automatically imports metadata of files added to the
        /// linked S3 bucket that do not currently exist in the FSx file system.</para></li><li><para><code>CHANGED</code> - Amazon FSx automatically updates file metadata and invalidates
        /// existing file content on the file system as files change in the data repository.</para></li><li><para><code>DELETED</code> - Amazon FSx automatically deletes files on the file system
        /// as corresponding files are deleted in the data repository.</para></li></ul><para>You can define any combination of event types for your <code>AutoImportPolicy</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3_AutoImportPolicy_Events")]
        public System.String[] AutoImportPolicy_Event { get; set; }
        #endregion
        
        #region Parameter ImportedFileChunkSize
        /// <summary>
        /// <para>
        /// <para>For files imported from a data repository, this value determines the stripe count
        /// and maximum amount of data per file (in MiB) stored on a single physical disk. The
        /// maximum number of disks that a single file can be striped across is limited by the
        /// total number of disks that make up the file system.</para><para>The default chunk size is 1,024 MiB (1 GiB) and can go as high as 512,000 MiB (500
        /// GiB). Amazon S3 objects have a maximum size of 5 TB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ImportedFileChunkSize { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Association'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.UpdateDataRepositoryAssociationResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.UpdateDataRepositoryAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Association";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AssociationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AssociationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AssociationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssociationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FSXDataRepositoryAssociation (UpdateDataRepositoryAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.UpdateDataRepositoryAssociationResponse, UpdateFSXDataRepositoryAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AssociationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AssociationId = this.AssociationId;
            #if MODULAR
            if (this.AssociationId == null && ParameterWasBound(nameof(this.AssociationId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.ImportedFileChunkSize = this.ImportedFileChunkSize;
            if (this.AutoExportPolicy_Event != null)
            {
                context.AutoExportPolicy_Event = new List<System.String>(this.AutoExportPolicy_Event);
            }
            if (this.AutoImportPolicy_Event != null)
            {
                context.AutoImportPolicy_Event = new List<System.String>(this.AutoImportPolicy_Event);
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
            var request = new Amazon.FSx.Model.UpdateDataRepositoryAssociationRequest();
            
            if (cmdletContext.AssociationId != null)
            {
                request.AssociationId = cmdletContext.AssociationId;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ImportedFileChunkSize != null)
            {
                request.ImportedFileChunkSize = cmdletContext.ImportedFileChunkSize.Value;
            }
            
             // populate S3
            var requestS3IsNull = true;
            request.S3 = new Amazon.FSx.Model.S3DataRepositoryConfiguration();
            Amazon.FSx.Model.AutoExportPolicy requestS3_s3_AutoExportPolicy = null;
            
             // populate AutoExportPolicy
            var requestS3_s3_AutoExportPolicyIsNull = true;
            requestS3_s3_AutoExportPolicy = new Amazon.FSx.Model.AutoExportPolicy();
            List<System.String> requestS3_s3_AutoExportPolicy_autoExportPolicy_Event = null;
            if (cmdletContext.AutoExportPolicy_Event != null)
            {
                requestS3_s3_AutoExportPolicy_autoExportPolicy_Event = cmdletContext.AutoExportPolicy_Event;
            }
            if (requestS3_s3_AutoExportPolicy_autoExportPolicy_Event != null)
            {
                requestS3_s3_AutoExportPolicy.Events = requestS3_s3_AutoExportPolicy_autoExportPolicy_Event;
                requestS3_s3_AutoExportPolicyIsNull = false;
            }
             // determine if requestS3_s3_AutoExportPolicy should be set to null
            if (requestS3_s3_AutoExportPolicyIsNull)
            {
                requestS3_s3_AutoExportPolicy = null;
            }
            if (requestS3_s3_AutoExportPolicy != null)
            {
                request.S3.AutoExportPolicy = requestS3_s3_AutoExportPolicy;
                requestS3IsNull = false;
            }
            Amazon.FSx.Model.AutoImportPolicy requestS3_s3_AutoImportPolicy = null;
            
             // populate AutoImportPolicy
            var requestS3_s3_AutoImportPolicyIsNull = true;
            requestS3_s3_AutoImportPolicy = new Amazon.FSx.Model.AutoImportPolicy();
            List<System.String> requestS3_s3_AutoImportPolicy_autoImportPolicy_Event = null;
            if (cmdletContext.AutoImportPolicy_Event != null)
            {
                requestS3_s3_AutoImportPolicy_autoImportPolicy_Event = cmdletContext.AutoImportPolicy_Event;
            }
            if (requestS3_s3_AutoImportPolicy_autoImportPolicy_Event != null)
            {
                requestS3_s3_AutoImportPolicy.Events = requestS3_s3_AutoImportPolicy_autoImportPolicy_Event;
                requestS3_s3_AutoImportPolicyIsNull = false;
            }
             // determine if requestS3_s3_AutoImportPolicy should be set to null
            if (requestS3_s3_AutoImportPolicyIsNull)
            {
                requestS3_s3_AutoImportPolicy = null;
            }
            if (requestS3_s3_AutoImportPolicy != null)
            {
                request.S3.AutoImportPolicy = requestS3_s3_AutoImportPolicy;
                requestS3IsNull = false;
            }
             // determine if request.S3 should be set to null
            if (requestS3IsNull)
            {
                request.S3 = null;
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
        
        private Amazon.FSx.Model.UpdateDataRepositoryAssociationResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.UpdateDataRepositoryAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "UpdateDataRepositoryAssociation");
            try
            {
                #if DESKTOP
                return client.UpdateDataRepositoryAssociation(request);
                #elif CORECLR
                return client.UpdateDataRepositoryAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.String AssociationId { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.Int32? ImportedFileChunkSize { get; set; }
            public List<System.String> AutoExportPolicy_Event { get; set; }
            public List<System.String> AutoImportPolicy_Event { get; set; }
            public System.Func<Amazon.FSx.Model.UpdateDataRepositoryAssociationResponse, UpdateFSXDataRepositoryAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Association;
        }
        
    }
}
