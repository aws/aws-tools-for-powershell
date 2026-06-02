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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Returns the JSON schema for a specified job category and schema version. Use this
    /// schema to validate your <c>JobConfigDocument</c> before calling <c>CreateJob</c>.
    /// If you don't specify a schema version, the latest version is returned. The schema
    /// defines required fields, allowed values, and constraints for the job configuration.
    /// 
    ///  
    /// <para>
    /// The following operations are related to <c>DescribeJobSchemaVersion</c>:
    /// </para><ul><li><para><c>ListJobSchemaVersions</c></para></li><li><para><c>CreateJob</c></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "SMJobSchemaVersionDetail")]
    [OutputType("Amazon.SageMaker.Model.DescribeJobSchemaVersionResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service DescribeJobSchemaVersion API operation.", Operation = new[] {"DescribeJobSchemaVersion"}, SelectReturnType = typeof(Amazon.SageMaker.Model.DescribeJobSchemaVersionResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.DescribeJobSchemaVersionResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.DescribeJobSchemaVersionResponse object containing multiple properties."
    )]
    public partial class GetSMJobSchemaVersionDetailCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter JobCategory
        /// <summary>
        /// <para>
        /// <para>The category of the job schema to describe.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMaker.JobCategory")]
        public Amazon.SageMaker.JobCategory JobCategory { get; set; }
        #endregion
        
        #region Parameter JobConfigSchemaVersion
        /// <summary>
        /// <para>
        /// <para>The version of the schema to retrieve. If not specified, the latest version is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobConfigSchemaVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.DescribeJobSchemaVersionResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.DescribeJobSchemaVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.DescribeJobSchemaVersionResponse, GetSMJobSchemaVersionDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.JobCategory = this.JobCategory;
            #if MODULAR
            if (this.JobCategory == null && ParameterWasBound(nameof(this.JobCategory)))
            {
                WriteWarning("You are passing $null as a value for parameter JobCategory which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobConfigSchemaVersion = this.JobConfigSchemaVersion;
            
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
            var request = new Amazon.SageMaker.Model.DescribeJobSchemaVersionRequest();
            
            if (cmdletContext.JobCategory != null)
            {
                request.JobCategory = cmdletContext.JobCategory;
            }
            if (cmdletContext.JobConfigSchemaVersion != null)
            {
                request.JobConfigSchemaVersion = cmdletContext.JobConfigSchemaVersion;
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
        
        private Amazon.SageMaker.Model.DescribeJobSchemaVersionResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.DescribeJobSchemaVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "DescribeJobSchemaVersion");
            try
            {
                return client.DescribeJobSchemaVersionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.SageMaker.JobCategory JobCategory { get; set; }
            public System.String JobConfigSchemaVersion { get; set; }
            public System.Func<Amazon.SageMaker.Model.DescribeJobSchemaVersionResponse, GetSMJobSchemaVersionDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
