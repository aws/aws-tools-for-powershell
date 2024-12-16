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
using Amazon.AppRegistry;
using Amazon.AppRegistry.Model;

namespace Amazon.PowerShell.Cmdlets.SCAR
{
    /// <summary>
    /// Associates a <c>TagKey</c> configuration to an account.
    /// </summary>
    [Cmdlet("Write", "SCARConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Service Catalog App Registry PutConfiguration API operation.", Operation = new[] {"PutConfiguration"}, SelectReturnType = typeof(Amazon.AppRegistry.Model.PutConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.AppRegistry.Model.PutConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AppRegistry.Model.PutConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteSCARConfigurationCmdlet : AmazonAppRegistryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TagQueryConfiguration_TagKey
        /// <summary>
        /// <para>
        /// <para> Condition in the IAM policy that associates resources to an application. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("Configuration_TagQueryConfiguration_TagKey")]
        public System.String TagQueryConfiguration_TagKey { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppRegistry.Model.PutConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TagQueryConfiguration_TagKey), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SCARConfiguration (PutConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppRegistry.Model.PutConfigurationResponse, WriteSCARConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TagQueryConfiguration_TagKey = this.TagQueryConfiguration_TagKey;
            
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
            var request = new Amazon.AppRegistry.Model.PutConfigurationRequest();
            
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.AppRegistry.Model.AppRegistryConfiguration();
            Amazon.AppRegistry.Model.TagQueryConfiguration requestConfiguration_configuration_TagQueryConfiguration = null;
            
             // populate TagQueryConfiguration
            var requestConfiguration_configuration_TagQueryConfigurationIsNull = true;
            requestConfiguration_configuration_TagQueryConfiguration = new Amazon.AppRegistry.Model.TagQueryConfiguration();
            System.String requestConfiguration_configuration_TagQueryConfiguration_tagQueryConfiguration_TagKey = null;
            if (cmdletContext.TagQueryConfiguration_TagKey != null)
            {
                requestConfiguration_configuration_TagQueryConfiguration_tagQueryConfiguration_TagKey = cmdletContext.TagQueryConfiguration_TagKey;
            }
            if (requestConfiguration_configuration_TagQueryConfiguration_tagQueryConfiguration_TagKey != null)
            {
                requestConfiguration_configuration_TagQueryConfiguration.TagKey = requestConfiguration_configuration_TagQueryConfiguration_tagQueryConfiguration_TagKey;
                requestConfiguration_configuration_TagQueryConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_TagQueryConfiguration should be set to null
            if (requestConfiguration_configuration_TagQueryConfigurationIsNull)
            {
                requestConfiguration_configuration_TagQueryConfiguration = null;
            }
            if (requestConfiguration_configuration_TagQueryConfiguration != null)
            {
                request.Configuration.TagQueryConfiguration = requestConfiguration_configuration_TagQueryConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
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
        
        private Amazon.AppRegistry.Model.PutConfigurationResponse CallAWSServiceOperation(IAmazonAppRegistry client, Amazon.AppRegistry.Model.PutConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog App Registry", "PutConfiguration");
            try
            {
                #if DESKTOP
                return client.PutConfiguration(request);
                #elif CORECLR
                return client.PutConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String TagQueryConfiguration_TagKey { get; set; }
            public System.Func<Amazon.AppRegistry.Model.PutConfigurationResponse, WriteSCARConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
