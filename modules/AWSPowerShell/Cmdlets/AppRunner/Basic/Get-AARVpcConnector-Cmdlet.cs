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
    /// Return a description of an App Runner VPC connector resource.
    /// </summary>
    [Cmdlet("Get", "AARVpcConnector")]
    [OutputType("Amazon.AppRunner.Model.VpcConnector")]
    [AWSCmdlet("Calls the AWS App Runner DescribeVpcConnector API operation.", Operation = new[] {"DescribeVpcConnector"}, SelectReturnType = typeof(Amazon.AppRunner.Model.DescribeVpcConnectorResponse))]
    [AWSCmdletOutput("Amazon.AppRunner.Model.VpcConnector or Amazon.AppRunner.Model.DescribeVpcConnectorResponse",
        "This cmdlet returns an Amazon.AppRunner.Model.VpcConnector object.",
        "The service call response (type Amazon.AppRunner.Model.DescribeVpcConnectorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAARVpcConnectorCmdlet : AmazonAppRunnerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter VpcConnectorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the App Runner VPC connector that you want a description
        /// for.</para><para>The ARN must be a full VPC connector ARN.</para>
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
        public System.String VpcConnectorArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpcConnector'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppRunner.Model.DescribeVpcConnectorResponse).
        /// Specifying the name of a property of type Amazon.AppRunner.Model.DescribeVpcConnectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpcConnector";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VpcConnectorArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VpcConnectorArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VpcConnectorArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppRunner.Model.DescribeVpcConnectorResponse, GetAARVpcConnectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VpcConnectorArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.VpcConnectorArn = this.VpcConnectorArn;
            #if MODULAR
            if (this.VpcConnectorArn == null && ParameterWasBound(nameof(this.VpcConnectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcConnectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppRunner.Model.DescribeVpcConnectorRequest();
            
            if (cmdletContext.VpcConnectorArn != null)
            {
                request.VpcConnectorArn = cmdletContext.VpcConnectorArn;
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
        
        private Amazon.AppRunner.Model.DescribeVpcConnectorResponse CallAWSServiceOperation(IAmazonAppRunner client, Amazon.AppRunner.Model.DescribeVpcConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS App Runner", "DescribeVpcConnector");
            try
            {
                #if DESKTOP
                return client.DescribeVpcConnector(request);
                #elif CORECLR
                return client.DescribeVpcConnectorAsync(request).GetAwaiter().GetResult();
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
            public System.String VpcConnectorArn { get; set; }
            public System.Func<Amazon.AppRunner.Model.DescribeVpcConnectorResponse, GetAARVpcConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpcConnector;
        }
        
    }
}
