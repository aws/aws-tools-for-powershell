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
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Returns the current <c>LifecycleConfiguration</c> object for the specified EFS file
    /// system. Lifecycle management uses the <c>LifecycleConfiguration</c> object to identify
    /// when to move files between storage classes. For a file system without a <c>LifecycleConfiguration</c>
    /// object, the call returns an empty array in the response.
    /// 
    ///  
    /// <para>
    /// This operation requires permissions for the <c>elasticfilesystem:DescribeLifecycleConfiguration</c>
    /// operation.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EFSLifecycleConfiguration")]
    [OutputType("Amazon.ElasticFileSystem.Model.LifecyclePolicy")]
    [AWSCmdlet("Calls the Amazon Elastic File System DescribeLifecycleConfiguration API operation.", Operation = new[] {"DescribeLifecycleConfiguration"}, SelectReturnType = typeof(Amazon.ElasticFileSystem.Model.DescribeLifecycleConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ElasticFileSystem.Model.LifecyclePolicy or Amazon.ElasticFileSystem.Model.DescribeLifecycleConfigurationResponse",
        "This cmdlet returns a collection of Amazon.ElasticFileSystem.Model.LifecyclePolicy objects.",
        "The service call response (type Amazon.ElasticFileSystem.Model.DescribeLifecycleConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEFSLifecycleConfigurationCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// <para>The ID of the file system whose <c>LifecycleConfiguration</c> object you want to retrieve
        /// (String).</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LifecyclePolicies'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticFileSystem.Model.DescribeLifecycleConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ElasticFileSystem.Model.DescribeLifecycleConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LifecyclePolicies";
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
                context.Select = CreateSelectDelegate<Amazon.ElasticFileSystem.Model.DescribeLifecycleConfigurationResponse, GetEFSLifecycleConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FileSystemId = this.FileSystemId;
            #if MODULAR
            if (this.FileSystemId == null && ParameterWasBound(nameof(this.FileSystemId)))
            {
                WriteWarning("You are passing $null as a value for parameter FileSystemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticFileSystem.Model.DescribeLifecycleConfigurationRequest();
            
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
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
        
        private Amazon.ElasticFileSystem.Model.DescribeLifecycleConfigurationResponse CallAWSServiceOperation(IAmazonElasticFileSystem client, Amazon.ElasticFileSystem.Model.DescribeLifecycleConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic File System", "DescribeLifecycleConfiguration");
            try
            {
                return client.DescribeLifecycleConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.ElasticFileSystem.Model.DescribeLifecycleConfigurationResponse, GetEFSLifecycleConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LifecyclePolicies;
        }
        
    }
}
