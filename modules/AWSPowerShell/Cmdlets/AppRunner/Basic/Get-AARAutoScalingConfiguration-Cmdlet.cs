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
using Amazon.AppRunner;
using Amazon.AppRunner.Model;

namespace Amazon.PowerShell.Cmdlets.AAR
{
    /// <summary>
    /// Return a full description of an App Runner automatic scaling configuration resource.
    /// </summary>
    [Cmdlet("Get", "AARAutoScalingConfiguration")]
    [OutputType("Amazon.AppRunner.Model.AutoScalingConfiguration")]
    [AWSCmdlet("Calls the AWS App Runner DescribeAutoScalingConfiguration API operation.", Operation = new[] {"DescribeAutoScalingConfiguration"}, SelectReturnType = typeof(Amazon.AppRunner.Model.DescribeAutoScalingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.AppRunner.Model.AutoScalingConfiguration or Amazon.AppRunner.Model.DescribeAutoScalingConfigurationResponse",
        "This cmdlet returns an Amazon.AppRunner.Model.AutoScalingConfiguration object.",
        "The service call response (type Amazon.AppRunner.Model.DescribeAutoScalingConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetAARAutoScalingConfigurationCmdlet : AmazonAppRunnerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AutoScalingConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the App Runner auto scaling configuration that you
        /// want a description for.</para><para>The ARN can be a full auto scaling configuration ARN, or a partial ARN ending with
        /// either <c>.../<i>name</i></c> or <c>.../<i>name</i>/<i>revision</i></c>. If a revision
        /// isn't specified, the latest active revision is described.</para>
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
        public System.String AutoScalingConfigurationArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AutoScalingConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppRunner.Model.DescribeAutoScalingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.AppRunner.Model.DescribeAutoScalingConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AutoScalingConfiguration";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppRunner.Model.DescribeAutoScalingConfigurationResponse, GetAARAutoScalingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoScalingConfigurationArn = this.AutoScalingConfigurationArn;
            #if MODULAR
            if (this.AutoScalingConfigurationArn == null && ParameterWasBound(nameof(this.AutoScalingConfigurationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoScalingConfigurationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppRunner.Model.DescribeAutoScalingConfigurationRequest();
            
            if (cmdletContext.AutoScalingConfigurationArn != null)
            {
                request.AutoScalingConfigurationArn = cmdletContext.AutoScalingConfigurationArn;
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
        
        private Amazon.AppRunner.Model.DescribeAutoScalingConfigurationResponse CallAWSServiceOperation(IAmazonAppRunner client, Amazon.AppRunner.Model.DescribeAutoScalingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS App Runner", "DescribeAutoScalingConfiguration");
            try
            {
                #if DESKTOP
                return client.DescribeAutoScalingConfiguration(request);
                #elif CORECLR
                return client.DescribeAutoScalingConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String AutoScalingConfigurationArn { get; set; }
            public System.Func<Amazon.AppRunner.Model.DescribeAutoScalingConfigurationResponse, GetAARAutoScalingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AutoScalingConfiguration;
        }
        
    }
}
