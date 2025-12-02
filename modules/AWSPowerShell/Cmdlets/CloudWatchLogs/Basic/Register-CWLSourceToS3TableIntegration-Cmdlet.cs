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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Associates a data source with an S3 Table Integration for query access in the 'logs'
    /// namespace. This enables querying log data using analytics engines that support Iceberg
    /// such as Amazon Athena, Amazon Redshift, and Apache Spark.
    /// </summary>
    [Cmdlet("Register", "CWLSourceToS3TableIntegration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs AssociateSourceToS3TableIntegration API operation.", Operation = new[] {"AssociateSourceToS3TableIntegration"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.AssociateSourceToS3TableIntegrationResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudWatchLogs.Model.AssociateSourceToS3TableIntegrationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudWatchLogs.Model.AssociateSourceToS3TableIntegrationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterCWLSourceToS3TableIntegrationCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IntegrationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the S3 Table Integration to associate the data source
        /// with.</para>
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
        public System.String IntegrationArn { get; set; }
        #endregion
        
        #region Parameter DataSource_Name
        /// <summary>
        /// <para>
        /// <para>The name of the data source.</para>
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
        public System.String DataSource_Name { get; set; }
        #endregion
        
        #region Parameter DataSource_Type
        /// <summary>
        /// <para>
        /// <para>The type of the data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSource_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Identifier'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.AssociateSourceToS3TableIntegrationResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.AssociateSourceToS3TableIntegrationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Identifier";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IntegrationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-CWLSourceToS3TableIntegration (AssociateSourceToS3TableIntegration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.AssociateSourceToS3TableIntegrationResponse, RegisterCWLSourceToS3TableIntegrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DataSource_Name = this.DataSource_Name;
            #if MODULAR
            if (this.DataSource_Name == null && ParameterWasBound(nameof(this.DataSource_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSource_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataSource_Type = this.DataSource_Type;
            context.IntegrationArn = this.IntegrationArn;
            #if MODULAR
            if (this.IntegrationArn == null && ParameterWasBound(nameof(this.IntegrationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IntegrationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchLogs.Model.AssociateSourceToS3TableIntegrationRequest();
            
            
             // populate DataSource
            var requestDataSourceIsNull = true;
            request.DataSource = new Amazon.CloudWatchLogs.Model.DataSource();
            System.String requestDataSource_dataSource_Name = null;
            if (cmdletContext.DataSource_Name != null)
            {
                requestDataSource_dataSource_Name = cmdletContext.DataSource_Name;
            }
            if (requestDataSource_dataSource_Name != null)
            {
                request.DataSource.Name = requestDataSource_dataSource_Name;
                requestDataSourceIsNull = false;
            }
            System.String requestDataSource_dataSource_Type = null;
            if (cmdletContext.DataSource_Type != null)
            {
                requestDataSource_dataSource_Type = cmdletContext.DataSource_Type;
            }
            if (requestDataSource_dataSource_Type != null)
            {
                request.DataSource.Type = requestDataSource_dataSource_Type;
                requestDataSourceIsNull = false;
            }
             // determine if request.DataSource should be set to null
            if (requestDataSourceIsNull)
            {
                request.DataSource = null;
            }
            if (cmdletContext.IntegrationArn != null)
            {
                request.IntegrationArn = cmdletContext.IntegrationArn;
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
        
        private Amazon.CloudWatchLogs.Model.AssociateSourceToS3TableIntegrationResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.AssociateSourceToS3TableIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "AssociateSourceToS3TableIntegration");
            try
            {
                return client.AssociateSourceToS3TableIntegrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DataSource_Name { get; set; }
            public System.String DataSource_Type { get; set; }
            public System.String IntegrationArn { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.AssociateSourceToS3TableIntegrationResponse, RegisterCWLSourceToS3TableIntegrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Identifier;
        }
        
    }
}
