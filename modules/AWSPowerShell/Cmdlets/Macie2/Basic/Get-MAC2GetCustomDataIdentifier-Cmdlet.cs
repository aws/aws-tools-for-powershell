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
using Amazon.Macie2;
using Amazon.Macie2.Model;

namespace Amazon.PowerShell.Cmdlets.MAC2
{
    /// <summary>
    /// Retrieves information about one or more custom data identifiers.
    /// </summary>
    [Cmdlet("Get", "MAC2GetCustomDataIdentifier")]
    [OutputType("Amazon.Macie2.Model.BatchGetCustomDataIdentifiersResponse")]
    [AWSCmdlet("Calls the Amazon Macie 2 BatchGetCustomDataIdentifiers API operation.", Operation = new[] {"BatchGetCustomDataIdentifiers"}, SelectReturnType = typeof(Amazon.Macie2.Model.BatchGetCustomDataIdentifiersResponse))]
    [AWSCmdletOutput("Amazon.Macie2.Model.BatchGetCustomDataIdentifiersResponse",
        "This cmdlet returns an Amazon.Macie2.Model.BatchGetCustomDataIdentifiersResponse object containing multiple properties."
    )]
    public partial class GetMAC2GetCustomDataIdentifierCmdlet : AmazonMacie2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>An array of custom data identifier IDs, one for each custom data identifier to retrieve
        /// information about.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ids")]
        public System.String[] Id { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Macie2.Model.BatchGetCustomDataIdentifiersResponse).
        /// Specifying the name of a property of type Amazon.Macie2.Model.BatchGetCustomDataIdentifiersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.Macie2.Model.BatchGetCustomDataIdentifiersResponse, GetMAC2GetCustomDataIdentifierCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Id != null)
            {
                context.Id = new List<System.String>(this.Id);
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
            var request = new Amazon.Macie2.Model.BatchGetCustomDataIdentifiersRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Ids = cmdletContext.Id;
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
        
        private Amazon.Macie2.Model.BatchGetCustomDataIdentifiersResponse CallAWSServiceOperation(IAmazonMacie2 client, Amazon.Macie2.Model.BatchGetCustomDataIdentifiersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie 2", "BatchGetCustomDataIdentifiers");
            try
            {
                #if DESKTOP
                return client.BatchGetCustomDataIdentifiers(request);
                #elif CORECLR
                return client.BatchGetCustomDataIdentifiersAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Id { get; set; }
            public System.Func<Amazon.Macie2.Model.BatchGetCustomDataIdentifiersResponse, GetMAC2GetCustomDataIdentifierCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
