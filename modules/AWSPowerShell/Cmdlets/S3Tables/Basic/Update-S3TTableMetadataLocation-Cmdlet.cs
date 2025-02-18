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
using System.Threading;
using Amazon.S3Tables;
using Amazon.S3Tables.Model;

namespace Amazon.PowerShell.Cmdlets.S3T
{
    /// <summary>
    /// Updates the metadata location for a table. The metadata location of a table must be
    /// an S3 URI that begins with the table's warehouse location. The metadata location for
    /// an Apache Iceberg table must end with <c>.metadata.json</c>, or if the metadata file
    /// is Gzip-compressed, <c>.metadata.json.gz</c>.
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3tables:UpdateTableMetadataLocation</c> permission to use this
    /// operation. 
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("Update", "S3TTableMetadataLocation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3Tables.Model.UpdateTableMetadataLocationResponse")]
    [AWSCmdlet("Calls the Amazon S3 Tables UpdateTableMetadataLocation API operation.", Operation = new[] {"UpdateTableMetadataLocation"}, SelectReturnType = typeof(Amazon.S3Tables.Model.UpdateTableMetadataLocationResponse))]
    [AWSCmdletOutput("Amazon.S3Tables.Model.UpdateTableMetadataLocationResponse",
        "This cmdlet returns an Amazon.S3Tables.Model.UpdateTableMetadataLocationResponse object containing multiple properties."
    )]
    public partial class UpdateS3TTableMetadataLocationCmdlet : AmazonS3TablesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MetadataLocation
        /// <summary>
        /// <para>
        /// <para>The new metadata location for the table. </para>
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
        public System.String MetadataLocation { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the table.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the table.</para>
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
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter TableBucketARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the table bucket. </para>
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
        public System.String TableBucketARN { get; set; }
        #endregion
        
        #region Parameter VersionToken
        /// <summary>
        /// <para>
        /// <para>The version token of the table. </para>
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
        public System.String VersionToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Tables.Model.UpdateTableMetadataLocationResponse).
        /// Specifying the name of a property of type Amazon.S3Tables.Model.UpdateTableMetadataLocationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-S3TTableMetadataLocation (UpdateTableMetadataLocation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Tables.Model.UpdateTableMetadataLocationResponse, UpdateS3TTableMetadataLocationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MetadataLocation = this.MetadataLocation;
            #if MODULAR
            if (this.MetadataLocation == null && ParameterWasBound(nameof(this.MetadataLocation)))
            {
                WriteWarning("You are passing $null as a value for parameter MetadataLocation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Namespace = this.Namespace;
            #if MODULAR
            if (this.Namespace == null && ParameterWasBound(nameof(this.Namespace)))
            {
                WriteWarning("You are passing $null as a value for parameter Namespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TableBucketARN = this.TableBucketARN;
            #if MODULAR
            if (this.TableBucketARN == null && ParameterWasBound(nameof(this.TableBucketARN)))
            {
                WriteWarning("You are passing $null as a value for parameter TableBucketARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VersionToken = this.VersionToken;
            #if MODULAR
            if (this.VersionToken == null && ParameterWasBound(nameof(this.VersionToken)))
            {
                WriteWarning("You are passing $null as a value for parameter VersionToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.S3Tables.Model.UpdateTableMetadataLocationRequest();
            
            if (cmdletContext.MetadataLocation != null)
            {
                request.MetadataLocation = cmdletContext.MetadataLocation;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.TableBucketARN != null)
            {
                request.TableBucketARN = cmdletContext.TableBucketARN;
            }
            if (cmdletContext.VersionToken != null)
            {
                request.VersionToken = cmdletContext.VersionToken;
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
        
        private Amazon.S3Tables.Model.UpdateTableMetadataLocationResponse CallAWSServiceOperation(IAmazonS3Tables client, Amazon.S3Tables.Model.UpdateTableMetadataLocationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Tables", "UpdateTableMetadataLocation");
            try
            {
                return client.UpdateTableMetadataLocationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String MetadataLocation { get; set; }
            public System.String Name { get; set; }
            public System.String Namespace { get; set; }
            public System.String TableBucketARN { get; set; }
            public System.String VersionToken { get; set; }
            public System.Func<Amazon.S3Tables.Model.UpdateTableMetadataLocationResponse, UpdateS3TTableMetadataLocationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
