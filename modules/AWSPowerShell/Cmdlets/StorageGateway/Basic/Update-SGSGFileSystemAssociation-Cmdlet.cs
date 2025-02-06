/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Updates a file system association. This operation is only supported in the FSx File
    /// Gateways.
    /// </summary>
    [Cmdlet("Update", "SGSGFileSystemAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Storage Gateway UpdateFileSystemAssociation API operation.", Operation = new[] {"UpdateFileSystemAssociation"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.UpdateFileSystemAssociationResponse))]
    [AWSCmdletOutput("System.String or Amazon.StorageGateway.Model.UpdateFileSystemAssociationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.StorageGateway.Model.UpdateFileSystemAssociationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSGSGFileSystemAssociationCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AuditDestinationARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the storage used for the audit logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuditDestinationARN { get; set; }
        #endregion
        
        #region Parameter CacheAttributes_CacheStaleTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>Refreshes a file share's cache by using Time To Live (TTL). TTL is the length of time
        /// since the last refresh after which access to the directory would cause the file gateway
        /// to first refresh that directory's contents from the Amazon S3 bucket or Amazon FSx
        /// file system. The TTL duration is in seconds.</para><para>Valid Values:0, 300 to 2,592,000 seconds (5 minutes to 30 days)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheAttributes_CacheStaleTimeoutInSeconds")]
        public System.Int32? CacheAttributes_CacheStaleTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter FileSystemAssociationARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the file system association that you want to update.</para>
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
        public System.String FileSystemAssociationARN { get; set; }
        #endregion
        
        #region Parameter Password
        /// <summary>
        /// <para>
        /// <para>The password of the user credential.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Password { get; set; }
        #endregion
        
        #region Parameter UserName
        /// <summary>
        /// <para>
        /// <para>The user name of the user credential that has permission to access the root share
        /// D$ of the Amazon FSx file system. The user account must belong to the Amazon FSx delegated
        /// admin user group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FileSystemAssociationARN'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.UpdateFileSystemAssociationResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.UpdateFileSystemAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FileSystemAssociationARN";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SGSGFileSystemAssociation (UpdateFileSystemAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.UpdateFileSystemAssociationResponse, UpdateSGSGFileSystemAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuditDestinationARN = this.AuditDestinationARN;
            context.CacheAttributes_CacheStaleTimeoutInSecond = this.CacheAttributes_CacheStaleTimeoutInSecond;
            context.FileSystemAssociationARN = this.FileSystemAssociationARN;
            #if MODULAR
            if (this.FileSystemAssociationARN == null && ParameterWasBound(nameof(this.FileSystemAssociationARN)))
            {
                WriteWarning("You are passing $null as a value for parameter FileSystemAssociationARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Password = this.Password;
            context.UserName = this.UserName;
            
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
            var request = new Amazon.StorageGateway.Model.UpdateFileSystemAssociationRequest();
            
            if (cmdletContext.AuditDestinationARN != null)
            {
                request.AuditDestinationARN = cmdletContext.AuditDestinationARN;
            }
            
             // populate CacheAttributes
            var requestCacheAttributesIsNull = true;
            request.CacheAttributes = new Amazon.StorageGateway.Model.CacheAttributes();
            System.Int32? requestCacheAttributes_cacheAttributes_CacheStaleTimeoutInSecond = null;
            if (cmdletContext.CacheAttributes_CacheStaleTimeoutInSecond != null)
            {
                requestCacheAttributes_cacheAttributes_CacheStaleTimeoutInSecond = cmdletContext.CacheAttributes_CacheStaleTimeoutInSecond.Value;
            }
            if (requestCacheAttributes_cacheAttributes_CacheStaleTimeoutInSecond != null)
            {
                request.CacheAttributes.CacheStaleTimeoutInSeconds = requestCacheAttributes_cacheAttributes_CacheStaleTimeoutInSecond.Value;
                requestCacheAttributesIsNull = false;
            }
             // determine if request.CacheAttributes should be set to null
            if (requestCacheAttributesIsNull)
            {
                request.CacheAttributes = null;
            }
            if (cmdletContext.FileSystemAssociationARN != null)
            {
                request.FileSystemAssociationARN = cmdletContext.FileSystemAssociationARN;
            }
            if (cmdletContext.Password != null)
            {
                request.Password = cmdletContext.Password;
            }
            if (cmdletContext.UserName != null)
            {
                request.UserName = cmdletContext.UserName;
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
        
        private Amazon.StorageGateway.Model.UpdateFileSystemAssociationResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.UpdateFileSystemAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "UpdateFileSystemAssociation");
            try
            {
                #if DESKTOP
                return client.UpdateFileSystemAssociation(request);
                #elif CORECLR
                return client.UpdateFileSystemAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.String AuditDestinationARN { get; set; }
            public System.Int32? CacheAttributes_CacheStaleTimeoutInSecond { get; set; }
            public System.String FileSystemAssociationARN { get; set; }
            public System.String Password { get; set; }
            public System.String UserName { get; set; }
            public System.Func<Amazon.StorageGateway.Model.UpdateFileSystemAssociationResponse, UpdateSGSGFileSystemAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FileSystemAssociationARN;
        }
        
    }
}
