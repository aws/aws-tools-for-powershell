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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Returns a list of available log streams for a specific database in Amazon Lightsail.
    /// </summary>
    [Cmdlet("Get", "LSRelationalDatabaseLogStream")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Lightsail GetRelationalDatabaseLogStreams API operation.", Operation = new[] {"GetRelationalDatabaseLogStreams"}, SelectReturnType = typeof(Amazon.Lightsail.Model.GetRelationalDatabaseLogStreamsResponse))]
    [AWSCmdletOutput("System.String or Amazon.Lightsail.Model.GetRelationalDatabaseLogStreamsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.Lightsail.Model.GetRelationalDatabaseLogStreamsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLSRelationalDatabaseLogStreamCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RelationalDatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of your database for which to get log streams.</para>
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
        public System.String RelationalDatabaseName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LogStreams'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.GetRelationalDatabaseLogStreamsResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.GetRelationalDatabaseLogStreamsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LogStreams";
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
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.GetRelationalDatabaseLogStreamsResponse, GetLSRelationalDatabaseLogStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RelationalDatabaseName = this.RelationalDatabaseName;
            #if MODULAR
            if (this.RelationalDatabaseName == null && ParameterWasBound(nameof(this.RelationalDatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter RelationalDatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Lightsail.Model.GetRelationalDatabaseLogStreamsRequest();
            
            if (cmdletContext.RelationalDatabaseName != null)
            {
                request.RelationalDatabaseName = cmdletContext.RelationalDatabaseName;
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
        
        private Amazon.Lightsail.Model.GetRelationalDatabaseLogStreamsResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.GetRelationalDatabaseLogStreamsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "GetRelationalDatabaseLogStreams");
            try
            {
                #if DESKTOP
                return client.GetRelationalDatabaseLogStreams(request);
                #elif CORECLR
                return client.GetRelationalDatabaseLogStreamsAsync(request).GetAwaiter().GetResult();
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
            public System.String RelationalDatabaseName { get; set; }
            public System.Func<Amazon.Lightsail.Model.GetRelationalDatabaseLogStreamsResponse, GetLSRelationalDatabaseLogStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LogStreams;
        }
        
    }
}
