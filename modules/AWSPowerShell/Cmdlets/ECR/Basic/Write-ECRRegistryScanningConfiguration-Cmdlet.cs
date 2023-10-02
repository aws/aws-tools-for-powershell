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
using Amazon.ECR;
using Amazon.ECR.Model;

namespace Amazon.PowerShell.Cmdlets.ECR
{
    /// <summary>
    /// Creates or updates the scanning configuration for your private registry.
    /// </summary>
    [Cmdlet("Write", "ECRRegistryScanningConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECR.Model.RegistryScanningConfiguration")]
    [AWSCmdlet("Calls the Amazon EC2 Container Registry PutRegistryScanningConfiguration API operation.", Operation = new[] {"PutRegistryScanningConfiguration"}, SelectReturnType = typeof(Amazon.ECR.Model.PutRegistryScanningConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ECR.Model.RegistryScanningConfiguration or Amazon.ECR.Model.PutRegistryScanningConfigurationResponse",
        "This cmdlet returns an Amazon.ECR.Model.RegistryScanningConfiguration object.",
        "The service call response (type Amazon.ECR.Model.PutRegistryScanningConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteECRRegistryScanningConfigurationCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Rule
        /// <summary>
        /// <para>
        /// <para>The scanning rules to use for the registry. A scanning rule is used to determine which
        /// repository filters are used and at what frequency scanning will occur.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rules")]
        public Amazon.ECR.Model.RegistryScanningRule[] Rule { get; set; }
        #endregion
        
        #region Parameter ScanType
        /// <summary>
        /// <para>
        /// <para>The scanning type to set for the registry.</para><para>When a registry scanning configuration is not defined, by default the <code>BASIC</code>
        /// scan type is used. When basic scanning is used, you may specify filters to determine
        /// which individual repositories, or all repositories, are scanned when new images are
        /// pushed to those repositories. Alternatively, you can do manual scans of images with
        /// basic scanning.</para><para>When the <code>ENHANCED</code> scan type is set, Amazon Inspector provides automated
        /// vulnerability scanning. You may choose between continuous scanning or scan on push
        /// and you may specify filters to determine which individual repositories, or all repositories,
        /// are scanned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECR.ScanType")]
        public Amazon.ECR.ScanType ScanType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RegistryScanningConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECR.Model.PutRegistryScanningConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ECR.Model.PutRegistryScanningConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RegistryScanningConfiguration";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ECRRegistryScanningConfiguration (PutRegistryScanningConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECR.Model.PutRegistryScanningConfigurationResponse, WriteECRRegistryScanningConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Rule != null)
            {
                context.Rule = new List<Amazon.ECR.Model.RegistryScanningRule>(this.Rule);
            }
            context.ScanType = this.ScanType;
            
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
            var request = new Amazon.ECR.Model.PutRegistryScanningConfigurationRequest();
            
            if (cmdletContext.Rule != null)
            {
                request.Rules = cmdletContext.Rule;
            }
            if (cmdletContext.ScanType != null)
            {
                request.ScanType = cmdletContext.ScanType;
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
        
        private Amazon.ECR.Model.PutRegistryScanningConfigurationResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.PutRegistryScanningConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Registry", "PutRegistryScanningConfiguration");
            try
            {
                #if DESKTOP
                return client.PutRegistryScanningConfiguration(request);
                #elif CORECLR
                return client.PutRegistryScanningConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ECR.Model.RegistryScanningRule> Rule { get; set; }
            public Amazon.ECR.ScanType ScanType { get; set; }
            public System.Func<Amazon.ECR.Model.PutRegistryScanningConfigurationResponse, WriteECRRegistryScanningConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RegistryScanningConfiguration;
        }
        
    }
}
