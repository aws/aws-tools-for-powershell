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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Describes the attached files configuration for the specified Connect Customer instance
    /// and attachment scope.
    /// 
    ///  
    /// <para>
    /// If a custom configuration exists for the specified attachment scope, the custom configuration
    /// is returned. If no custom configuration exists, the default configuration values for
    /// that attachment scope are returned.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CONNAttachedFilesConfigurationDetail")]
    [OutputType("Amazon.Connect.Model.AttachedFilesConfiguration")]
    [AWSCmdlet("Calls the Amazon Connect Service DescribeAttachedFilesConfiguration API operation.", Operation = new[] {"DescribeAttachedFilesConfiguration"}, SelectReturnType = typeof(Amazon.Connect.Model.DescribeAttachedFilesConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.AttachedFilesConfiguration or Amazon.Connect.Model.DescribeAttachedFilesConfigurationResponse",
        "This cmdlet returns an Amazon.Connect.Model.AttachedFilesConfiguration object.",
        "The service call response (type Amazon.Connect.Model.DescribeAttachedFilesConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCONNAttachedFilesConfigurationDetailCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AttachmentScope
        /// <summary>
        /// <para>
        /// <para>The scope of the attachment. Valid values are <c>EMAIL</c>, <c>CHAT</c>, <c>CASE</c>,
        /// and <c>TASK</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.AttachmentScope")]
        public Amazon.Connect.AttachmentScope AttachmentScope { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Connect Customer instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AttachedFilesConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.DescribeAttachedFilesConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.DescribeAttachedFilesConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AttachedFilesConfiguration";
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
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.DescribeAttachedFilesConfigurationResponse, GetCONNAttachedFilesConfigurationDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AttachmentScope = this.AttachmentScope;
            #if MODULAR
            if (this.AttachmentScope == null && ParameterWasBound(nameof(this.AttachmentScope)))
            {
                WriteWarning("You are passing $null as a value for parameter AttachmentScope which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.DescribeAttachedFilesConfigurationRequest();
            
            if (cmdletContext.AttachmentScope != null)
            {
                request.AttachmentScope = cmdletContext.AttachmentScope;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
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
        
        private Amazon.Connect.Model.DescribeAttachedFilesConfigurationResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.DescribeAttachedFilesConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "DescribeAttachedFilesConfiguration");
            try
            {
                return client.DescribeAttachedFilesConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Connect.AttachmentScope AttachmentScope { get; set; }
            public System.String InstanceId { get; set; }
            public System.Func<Amazon.Connect.Model.DescribeAttachedFilesConfigurationResponse, GetCONNAttachedFilesConfigurationDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AttachedFilesConfiguration;
        }
        
    }
}
