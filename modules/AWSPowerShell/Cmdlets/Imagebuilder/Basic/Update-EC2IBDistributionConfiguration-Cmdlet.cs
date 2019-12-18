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
    /// Updates a new distribution configuration. Distribution configurations define and
    /// configure the outputs of your pipeline.
    /// </summary>
    [Cmdlet("Update", "EC2IBDistributionConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the EC2 Image Builder UpdateDistributionConfiguration API operation.", Operation = new[] {"UpdateDistributionConfiguration"}, SelectReturnType = typeof(Amazon.Imagebuilder.Model.UpdateDistributionConfigurationResponse))]
    [AWSCmdletOutput("System.String or Amazon.Imagebuilder.Model.UpdateDistributionConfigurationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Imagebuilder.Model.UpdateDistributionConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateEC2IBDistributionConfigurationCmdlet : AmazonImagebuilderClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> The description of the distribution configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DistributionConfigurationArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the distribution configuration that you wish to
        /// update. </para>
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
        
        #region Parameter Distribution
        /// <summary>
        /// <para>
        /// <para> The distributions of the distribution configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Distributions")]
        public Amazon.Imagebuilder.Model.Distribution[] Distribution { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> The idempotency token of the distribution configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DistributionConfigurationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Imagebuilder.Model.UpdateDistributionConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Imagebuilder.Model.UpdateDistributionConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DistributionConfigurationArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DistributionConfigurationArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DistributionConfigurationArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DistributionConfigurationArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DistributionConfigurationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EC2IBDistributionConfiguration (UpdateDistributionConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Imagebuilder.Model.UpdateDistributionConfigurationResponse, UpdateEC2IBDistributionConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DistributionConfigurationArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DistributionConfigurationArn = this.DistributionConfigurationArn;
            #if MODULAR
            if (this.DistributionConfigurationArn == null && ParameterWasBound(nameof(this.DistributionConfigurationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DistributionConfigurationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Distribution != null)
            {
                context.Distribution = new List<Amazon.Imagebuilder.Model.Distribution>(this.Distribution);
            }
            
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
            var request = new Amazon.Imagebuilder.Model.UpdateDistributionConfigurationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DistributionConfigurationArn != null)
            {
                request.DistributionConfigurationArn = cmdletContext.DistributionConfigurationArn;
            }
            if (cmdletContext.Distribution != null)
            {
                request.Distributions = cmdletContext.Distribution;
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
        
        private Amazon.Imagebuilder.Model.UpdateDistributionConfigurationResponse CallAWSServiceOperation(IAmazonImagebuilder client, Amazon.Imagebuilder.Model.UpdateDistributionConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "EC2 Image Builder", "UpdateDistributionConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateDistributionConfiguration(request);
                #elif CORECLR
                return client.UpdateDistributionConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String DistributionConfigurationArn { get; set; }
            public List<Amazon.Imagebuilder.Model.Distribution> Distribution { get; set; }
            public System.Func<Amazon.Imagebuilder.Model.UpdateDistributionConfigurationResponse, UpdateEC2IBDistributionConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DistributionConfigurationArn;
        }
        
    }
}
