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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// The command to update the Kinesis stream destination.
    /// </summary>
    [Cmdlet("Update", "DDBKinesisStreamingDestination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.UpdateKinesisStreamingDestinationResponse")]
    [AWSCmdlet("Calls the Amazon DynamoDB UpdateKinesisStreamingDestination API operation.", Operation = new[] {"UpdateKinesisStreamingDestination"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.UpdateKinesisStreamingDestinationResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.UpdateKinesisStreamingDestinationResponse",
        "This cmdlet returns an Amazon.DynamoDBv2.Model.UpdateKinesisStreamingDestinationResponse object containing multiple properties."
    )]
    public partial class UpdateDDBKinesisStreamingDestinationCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter UpdateKinesisStreamingConfiguration_ApproximateCreationDateTimePrecision
        /// <summary>
        /// <para>
        /// <para>Enables updating the precision of Kinesis data stream timestamp. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ApproximateCreationDateTimePrecision")]
        public Amazon.DynamoDBv2.ApproximateCreationDateTimePrecision UpdateKinesisStreamingConfiguration_ApproximateCreationDateTimePrecision { get; set; }
        #endregion
        
        #region Parameter StreamArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the Kinesis stream input.</para>
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
        public System.String StreamArn { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The table name for the Kinesis streaming destination input. You can also provide the
        /// ARN of the table in this parameter.</para>
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
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.UpdateKinesisStreamingDestinationResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.UpdateKinesisStreamingDestinationResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TableName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DDBKinesisStreamingDestination (UpdateKinesisStreamingDestination)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.UpdateKinesisStreamingDestinationResponse, UpdateDDBKinesisStreamingDestinationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.StreamArn = this.StreamArn;
            #if MODULAR
            if (this.StreamArn == null && ParameterWasBound(nameof(this.StreamArn)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TableName = this.TableName;
            #if MODULAR
            if (this.TableName == null && ParameterWasBound(nameof(this.TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UpdateKinesisStreamingConfiguration_ApproximateCreationDateTimePrecision = this.UpdateKinesisStreamingConfiguration_ApproximateCreationDateTimePrecision;
            
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
            var request = new Amazon.DynamoDBv2.Model.UpdateKinesisStreamingDestinationRequest();
            
            if (cmdletContext.StreamArn != null)
            {
                request.StreamArn = cmdletContext.StreamArn;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
            }
            
             // populate UpdateKinesisStreamingConfiguration
            var requestUpdateKinesisStreamingConfigurationIsNull = true;
            request.UpdateKinesisStreamingConfiguration = new Amazon.DynamoDBv2.Model.UpdateKinesisStreamingConfiguration();
            Amazon.DynamoDBv2.ApproximateCreationDateTimePrecision requestUpdateKinesisStreamingConfiguration_updateKinesisStreamingConfiguration_ApproximateCreationDateTimePrecision = null;
            if (cmdletContext.UpdateKinesisStreamingConfiguration_ApproximateCreationDateTimePrecision != null)
            {
                requestUpdateKinesisStreamingConfiguration_updateKinesisStreamingConfiguration_ApproximateCreationDateTimePrecision = cmdletContext.UpdateKinesisStreamingConfiguration_ApproximateCreationDateTimePrecision;
            }
            if (requestUpdateKinesisStreamingConfiguration_updateKinesisStreamingConfiguration_ApproximateCreationDateTimePrecision != null)
            {
                request.UpdateKinesisStreamingConfiguration.ApproximateCreationDateTimePrecision = requestUpdateKinesisStreamingConfiguration_updateKinesisStreamingConfiguration_ApproximateCreationDateTimePrecision;
                requestUpdateKinesisStreamingConfigurationIsNull = false;
            }
             // determine if request.UpdateKinesisStreamingConfiguration should be set to null
            if (requestUpdateKinesisStreamingConfigurationIsNull)
            {
                request.UpdateKinesisStreamingConfiguration = null;
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
        
        private Amazon.DynamoDBv2.Model.UpdateKinesisStreamingDestinationResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.UpdateKinesisStreamingDestinationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "UpdateKinesisStreamingDestination");
            try
            {
                return client.UpdateKinesisStreamingDestinationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String StreamArn { get; set; }
            public System.String TableName { get; set; }
            public Amazon.DynamoDBv2.ApproximateCreationDateTimePrecision UpdateKinesisStreamingConfiguration_ApproximateCreationDateTimePrecision { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.UpdateKinesisStreamingDestinationResponse, UpdateDDBKinesisStreamingDestinationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
