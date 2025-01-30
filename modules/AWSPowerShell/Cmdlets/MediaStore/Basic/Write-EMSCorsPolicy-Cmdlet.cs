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
using Amazon.MediaStore;
using Amazon.MediaStore.Model;

namespace Amazon.PowerShell.Cmdlets.EMS
{
    /// <summary>
    /// Sets the cross-origin resource sharing (CORS) configuration on a container so that
    /// the container can service cross-origin requests. For example, you might want to enable
    /// a request whose origin is http://www.example.com to access your AWS Elemental MediaStore
    /// container at my.example.container.com by using the browser's XMLHttpRequest capability.
    /// 
    ///  
    /// <para>
    /// To enable CORS on a container, you attach a CORS policy to the container. In the CORS
    /// policy, you configure rules that identify origins and the HTTP methods that can be
    /// executed on your container. The policy can contain up to 398,000 characters. You can
    /// add up to 100 rules to a CORS policy. If more than one rule applies, the service uses
    /// the first applicable rule listed.
    /// </para><para>
    /// To learn more about CORS, see <a href="https://docs.aws.amazon.com/mediastore/latest/ug/cors-policy.html">Cross-Origin
    /// Resource Sharing (CORS) in AWS Elemental MediaStore</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "EMSCorsPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Elemental MediaStore PutCorsPolicy API operation.", Operation = new[] {"PutCorsPolicy"}, SelectReturnType = typeof(Amazon.MediaStore.Model.PutCorsPolicyResponse))]
    [AWSCmdletOutput("None or Amazon.MediaStore.Model.PutCorsPolicyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MediaStore.Model.PutCorsPolicyResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteEMSCorsPolicyCmdlet : AmazonMediaStoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContainerName
        /// <summary>
        /// <para>
        /// <para>The name of the container that you want to assign the CORS policy to.</para>
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
        public System.String ContainerName { get; set; }
        #endregion
        
        #region Parameter CorsPolicy
        /// <summary>
        /// <para>
        /// <para>The CORS policy to apply to the container. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.MediaStore.Model.CorsRule[] CorsPolicy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaStore.Model.PutCorsPolicyResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ContainerName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ContainerName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ContainerName' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ContainerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EMSCorsPolicy (PutCorsPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaStore.Model.PutCorsPolicyResponse, WriteEMSCorsPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ContainerName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContainerName = this.ContainerName;
            #if MODULAR
            if (this.ContainerName == null && ParameterWasBound(nameof(this.ContainerName)))
            {
                WriteWarning("You are passing $null as a value for parameter ContainerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CorsPolicy != null)
            {
                context.CorsPolicy = new List<Amazon.MediaStore.Model.CorsRule>(this.CorsPolicy);
            }
            #if MODULAR
            if (this.CorsPolicy == null && ParameterWasBound(nameof(this.CorsPolicy)))
            {
                WriteWarning("You are passing $null as a value for parameter CorsPolicy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MediaStore.Model.PutCorsPolicyRequest();
            
            if (cmdletContext.ContainerName != null)
            {
                request.ContainerName = cmdletContext.ContainerName;
            }
            if (cmdletContext.CorsPolicy != null)
            {
                request.CorsPolicy = cmdletContext.CorsPolicy;
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
        
        private Amazon.MediaStore.Model.PutCorsPolicyResponse CallAWSServiceOperation(IAmazonMediaStore client, Amazon.MediaStore.Model.PutCorsPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaStore", "PutCorsPolicy");
            try
            {
                #if DESKTOP
                return client.PutCorsPolicy(request);
                #elif CORECLR
                return client.PutCorsPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String ContainerName { get; set; }
            public List<Amazon.MediaStore.Model.CorsRule> CorsPolicy { get; set; }
            public System.Func<Amazon.MediaStore.Model.PutCorsPolicyResponse, WriteEMSCorsPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
