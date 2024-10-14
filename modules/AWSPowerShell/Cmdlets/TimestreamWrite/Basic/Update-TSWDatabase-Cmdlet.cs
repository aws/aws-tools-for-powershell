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
using Amazon.TimestreamWrite;
using Amazon.TimestreamWrite.Model;

namespace Amazon.PowerShell.Cmdlets.TSW
{
    /// <summary>
    /// Modifies the KMS key for an existing database. While updating the database, you must
    /// specify the database name and the identifier of the new KMS key to be used (<c>KmsKeyId</c>).
    /// If there are any concurrent <c>UpdateDatabase</c> requests, first writer wins. 
    /// 
    ///  
    /// <para>
    /// See <a href="https://docs.aws.amazon.com/timestream/latest/developerguide/code-samples.update-db.html">code
    /// sample</a> for details.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "TSWDatabase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TimestreamWrite.Model.Database")]
    [AWSCmdlet("Calls the Amazon Timestream Write UpdateDatabase API operation.", Operation = new[] {"UpdateDatabase"}, SelectReturnType = typeof(Amazon.TimestreamWrite.Model.UpdateDatabaseResponse))]
    [AWSCmdletOutput("Amazon.TimestreamWrite.Model.Database or Amazon.TimestreamWrite.Model.UpdateDatabaseResponse",
        "This cmdlet returns an Amazon.TimestreamWrite.Model.Database object.",
        "The service call response (type Amazon.TimestreamWrite.Model.UpdateDatabaseResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateTSWDatabaseCmdlet : AmazonTimestreamWriteClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para> The name of the database. </para>
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
        public System.String DatabaseName { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para> The identifier of the new KMS key (<c>KmsKeyId</c>) to be used to encrypt the data
        /// stored in the database. If the <c>KmsKeyId</c> currently registered with the database
        /// is the same as the <c>KmsKeyId</c> in the request, there will not be any update. </para><para>You can specify the <c>KmsKeyId</c> using any of the following:</para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-east-1:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Alias name: <c>alias/ExampleAlias</c></para></li><li><para>Alias ARN: <c>arn:aws:kms:us-east-1:111122223333:alias/ExampleAlias</c></para></li></ul>
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
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Database'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TimestreamWrite.Model.UpdateDatabaseResponse).
        /// Specifying the name of a property of type Amazon.TimestreamWrite.Model.UpdateDatabaseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Database";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatabaseName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TSWDatabase (UpdateDatabase)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TimestreamWrite.Model.UpdateDatabaseResponse, UpdateTSWDatabaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DatabaseName = this.DatabaseName;
            #if MODULAR
            if (this.DatabaseName == null && ParameterWasBound(nameof(this.DatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyId = this.KmsKeyId;
            #if MODULAR
            if (this.KmsKeyId == null && ParameterWasBound(nameof(this.KmsKeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KmsKeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.TimestreamWrite.Model.UpdateDatabaseRequest();
            
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
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
        
        private Amazon.TimestreamWrite.Model.UpdateDatabaseResponse CallAWSServiceOperation(IAmazonTimestreamWrite client, Amazon.TimestreamWrite.Model.UpdateDatabaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Timestream Write", "UpdateDatabase");
            try
            {
                #if DESKTOP
                return client.UpdateDatabase(request);
                #elif CORECLR
                return client.UpdateDatabaseAsync(request).GetAwaiter().GetResult();
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
            public System.String DatabaseName { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.Func<Amazon.TimestreamWrite.Model.UpdateDatabaseResponse, UpdateTSWDatabaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Database;
        }
        
    }
}
