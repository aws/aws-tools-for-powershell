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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.S3T
{
    /// <summary>
    /// Retrieves the expiration configuration settings for records in a table, and the status
    /// of the configuration. If the status of the configuration is <c>enabled</c>, records
    /// expire and are automatically removed from the table after the specified number of
    /// days.
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3tables:GetTableRecordExpirationConfiguration</c> permission
    /// to use this operation.
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("Get", "S3TTableRecordExpirationConfiguration")]
    [OutputType("Amazon.S3Tables.Model.TableRecordExpirationConfigurationValue")]
    [AWSCmdlet("Calls the Amazon S3 Tables GetTableRecordExpirationConfiguration API operation.", Operation = new[] {"GetTableRecordExpirationConfiguration"}, SelectReturnType = typeof(Amazon.S3Tables.Model.GetTableRecordExpirationConfigurationResponse))]
    [AWSCmdletOutput("Amazon.S3Tables.Model.TableRecordExpirationConfigurationValue or Amazon.S3Tables.Model.GetTableRecordExpirationConfigurationResponse",
        "This cmdlet returns an Amazon.S3Tables.Model.TableRecordExpirationConfigurationValue object.",
        "The service call response (type Amazon.S3Tables.Model.GetTableRecordExpirationConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetS3TTableRecordExpirationConfigurationCmdlet : AmazonS3TablesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TableArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the table.</para>
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
        public System.String TableArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Configuration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Tables.Model.GetTableRecordExpirationConfigurationResponse).
        /// Specifying the name of a property of type Amazon.S3Tables.Model.GetTableRecordExpirationConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Configuration";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Tables.Model.GetTableRecordExpirationConfigurationResponse, GetS3TTableRecordExpirationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TableArn = this.TableArn;
            #if MODULAR
            if (this.TableArn == null && ParameterWasBound(nameof(this.TableArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TableArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.S3Tables.Model.GetTableRecordExpirationConfigurationRequest();
            
            if (cmdletContext.TableArn != null)
            {
                request.TableArn = cmdletContext.TableArn;
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
        
        private Amazon.S3Tables.Model.GetTableRecordExpirationConfigurationResponse CallAWSServiceOperation(IAmazonS3Tables client, Amazon.S3Tables.Model.GetTableRecordExpirationConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Tables", "GetTableRecordExpirationConfiguration");
            try
            {
                return client.GetTableRecordExpirationConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String TableArn { get; set; }
            public System.Func<Amazon.S3Tables.Model.GetTableRecordExpirationConfigurationResponse, GetS3TTableRecordExpirationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Configuration;
        }
        
    }
}
