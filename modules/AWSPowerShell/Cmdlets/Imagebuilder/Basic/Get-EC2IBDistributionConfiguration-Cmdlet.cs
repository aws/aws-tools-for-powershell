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
using Amazon.Imagebuilder;
using Amazon.Imagebuilder.Model;

namespace Amazon.PowerShell.Cmdlets.EC2IB
{
    /// <summary>
    /// Gets a distribution configuration.
    /// </summary>
    [Cmdlet("Get", "EC2IBDistributionConfiguration")]
    [OutputType("Amazon.Imagebuilder.Model.DistributionConfiguration")]
    [AWSCmdlet("Calls the EC2 Image Builder GetDistributionConfiguration API operation.", Operation = new[] {"GetDistributionConfiguration"}, SelectReturnType = typeof(Amazon.Imagebuilder.Model.GetDistributionConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Imagebuilder.Model.DistributionConfiguration or Amazon.Imagebuilder.Model.GetDistributionConfigurationResponse",
        "This cmdlet returns an Amazon.Imagebuilder.Model.DistributionConfiguration object.",
        "The service call response (type Amazon.Imagebuilder.Model.GetDistributionConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2IBDistributionConfigurationCmdlet : AmazonImagebuilderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DistributionConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the distribution configuration that you want to
        /// retrieve.</para>
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
        public System.String DistributionConfigurationArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DistributionConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Imagebuilder.Model.GetDistributionConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Imagebuilder.Model.GetDistributionConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DistributionConfiguration";
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
                context.Select = CreateSelectDelegate<Amazon.Imagebuilder.Model.GetDistributionConfigurationResponse, GetEC2IBDistributionConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DistributionConfigurationArn = this.DistributionConfigurationArn;
            #if MODULAR
            if (this.DistributionConfigurationArn == null && ParameterWasBound(nameof(this.DistributionConfigurationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DistributionConfigurationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Imagebuilder.Model.GetDistributionConfigurationRequest();
            
            if (cmdletContext.DistributionConfigurationArn != null)
            {
                request.DistributionConfigurationArn = cmdletContext.DistributionConfigurationArn;
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
        
        private Amazon.Imagebuilder.Model.GetDistributionConfigurationResponse CallAWSServiceOperation(IAmazonImagebuilder client, Amazon.Imagebuilder.Model.GetDistributionConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "EC2 Image Builder", "GetDistributionConfiguration");
            try
            {
                #if DESKTOP
                return client.GetDistributionConfiguration(request);
                #elif CORECLR
                return client.GetDistributionConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String DistributionConfigurationArn { get; set; }
            public System.Func<Amazon.Imagebuilder.Model.GetDistributionConfigurationResponse, GetEC2IBDistributionConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DistributionConfiguration;
        }
        
    }
}
