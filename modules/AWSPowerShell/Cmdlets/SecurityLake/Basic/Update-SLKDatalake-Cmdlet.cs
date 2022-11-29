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
using Amazon.SecurityLake;
using Amazon.SecurityLake.Model;

namespace Amazon.PowerShell.Cmdlets.SLK
{
    /// <summary>
    /// Amazon Security Lake allows you to specify where to store your security data and for
    /// how long. You can specify a rollup Region to consolidate data from multiple regions.
    /// 
    /// 
    ///  
    /// <para>
    /// You can update the properties of a Region or source. Input can either be directly
    /// specified to the API. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SLKDatalake", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Security Lake UpdateDatalake API operation.", Operation = new[] {"UpdateDatalake"}, SelectReturnType = typeof(Amazon.SecurityLake.Model.UpdateDatalakeResponse))]
    [AWSCmdletOutput("None or Amazon.SecurityLake.Model.UpdateDatalakeResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SecurityLake.Model.UpdateDatalakeResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSLKDatalakeCmdlet : AmazonSecurityLakeClientCmdlet, IExecutor
    {
        
        #region Parameter Configuration
        /// <summary>
        /// <para>
        /// <para>The configuration object</para>
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
        [Alias("Configurations")]
        public System.Collections.Hashtable Configuration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityLake.Model.UpdateDatalakeResponse).
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Configuration), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SLKDatalake (UpdateDatalake)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityLake.Model.UpdateDatalakeResponse, UpdateSLKDatalakeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Configuration != null)
            {
                context.Configuration = new Dictionary<System.String, Amazon.SecurityLake.Model.LakeConfigurationRequest>(StringComparer.Ordinal);
                foreach (var hashKey in this.Configuration.Keys)
                {
                    context.Configuration.Add((String)hashKey, (LakeConfigurationRequest)(this.Configuration[hashKey]));
                }
            }
            #if MODULAR
            if (this.Configuration == null && ParameterWasBound(nameof(this.Configuration)))
            {
                WriteWarning("You are passing $null as a value for parameter Configuration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityLake.Model.UpdateDatalakeRequest();
            
            if (cmdletContext.Configuration != null)
            {
                request.Configurations = cmdletContext.Configuration;
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
        
        private Amazon.SecurityLake.Model.UpdateDatalakeResponse CallAWSServiceOperation(IAmazonSecurityLake client, Amazon.SecurityLake.Model.UpdateDatalakeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Security Lake", "UpdateDatalake");
            try
            {
                #if DESKTOP
                return client.UpdateDatalake(request);
                #elif CORECLR
                return client.UpdateDatalakeAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.SecurityLake.Model.LakeConfigurationRequest> Configuration { get; set; }
            public System.Func<Amazon.SecurityLake.Model.UpdateDatalakeResponse, UpdateSLKDatalakeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
