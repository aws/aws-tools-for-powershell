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
using Amazon.Proton;
using Amazon.Proton.Model;

namespace Amazon.PowerShell.Cmdlets.PRO
{
    /// <summary>
    /// List provisioned resources for a service instance with details.
    /// </summary>
    [Cmdlet("Get", "PROServiceInstanceProvisionedResourceList")]
    [OutputType("Amazon.Proton.Model.ProvisionedResource")]
    [AWSCmdlet("Calls the AWS Proton ListServiceInstanceProvisionedResources API operation.", Operation = new[] {"ListServiceInstanceProvisionedResources"}, SelectReturnType = typeof(Amazon.Proton.Model.ListServiceInstanceProvisionedResourcesResponse))]
    [AWSCmdletOutput("Amazon.Proton.Model.ProvisionedResource or Amazon.Proton.Model.ListServiceInstanceProvisionedResourcesResponse",
        "This cmdlet returns a collection of Amazon.Proton.Model.ProvisionedResource objects.",
        "The service call response (type Amazon.Proton.Model.ListServiceInstanceProvisionedResourcesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetPROServiceInstanceProvisionedResourceListCmdlet : AmazonProtonClientCmdlet, IExecutor
    {
        
        #region Parameter ServiceInstanceName
        /// <summary>
        /// <para>
        /// <para>The service instance name.</para>
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
        public System.String ServiceInstanceName { get; set; }
        #endregion
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>The service name.</para>
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
        public System.String ServiceName { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token to indicate the location of the next provisioned resource in the array of
        /// provisioned resources, after the list of provisioned resources that was previously
        /// requested.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProvisionedResources'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Proton.Model.ListServiceInstanceProvisionedResourcesResponse).
        /// Specifying the name of a property of type Amazon.Proton.Model.ListServiceInstanceProvisionedResourcesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProvisionedResources";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Proton.Model.ListServiceInstanceProvisionedResourcesResponse, GetPROServiceInstanceProvisionedResourceListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.NextToken = this.NextToken;
            context.ServiceInstanceName = this.ServiceInstanceName;
            #if MODULAR
            if (this.ServiceInstanceName == null && ParameterWasBound(nameof(this.ServiceInstanceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceInstanceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceName = this.ServiceName;
            #if MODULAR
            if (this.ServiceName == null && ParameterWasBound(nameof(this.ServiceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Proton.Model.ListServiceInstanceProvisionedResourcesRequest();
            
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ServiceInstanceName != null)
            {
                request.ServiceInstanceName = cmdletContext.ServiceInstanceName;
            }
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceName = cmdletContext.ServiceName;
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
        
        private Amazon.Proton.Model.ListServiceInstanceProvisionedResourcesResponse CallAWSServiceOperation(IAmazonProton client, Amazon.Proton.Model.ListServiceInstanceProvisionedResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Proton", "ListServiceInstanceProvisionedResources");
            try
            {
                #if DESKTOP
                return client.ListServiceInstanceProvisionedResources(request);
                #elif CORECLR
                return client.ListServiceInstanceProvisionedResourcesAsync(request).GetAwaiter().GetResult();
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
            public System.String NextToken { get; set; }
            public System.String ServiceInstanceName { get; set; }
            public System.String ServiceName { get; set; }
            public System.Func<Amazon.Proton.Model.ListServiceInstanceProvisionedResourcesResponse, GetPROServiceInstanceProvisionedResourceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProvisionedResources;
        }
        
    }
}
