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
using Amazon.SsmSap;
using Amazon.SsmSap.Model;

namespace Amazon.PowerShell.Cmdlets.SMSAP
{
    /// <summary>
    /// Gets the SAP HANA database of an application registered with AWS Systems Manager for
    /// SAP.
    /// </summary>
    [Cmdlet("Get", "SMSAPDatabase")]
    [OutputType("Amazon.SsmSap.Model.GetDatabaseResponse")]
    [AWSCmdlet("Calls the AWS Systems Manager for SAP GetDatabase API operation.", Operation = new[] {"GetDatabase"}, SelectReturnType = typeof(Amazon.SsmSap.Model.GetDatabaseResponse))]
    [AWSCmdletOutput("Amazon.SsmSap.Model.GetDatabaseResponse",
        "This cmdlet returns an Amazon.SsmSap.Model.GetDatabaseResponse object containing multiple properties."
    )]
    public partial class GetSMSAPDatabaseCmdlet : AmazonSsmSapClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The ID of the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter ComponentId
        /// <summary>
        /// <para>
        /// <para>The ID of the component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComponentId { get; set; }
        #endregion
        
        #region Parameter DatabaseArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatabaseArn { get; set; }
        #endregion
        
        #region Parameter DatabaseId
        /// <summary>
        /// <para>
        /// <para>The ID of the database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatabaseId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SsmSap.Model.GetDatabaseResponse).
        /// Specifying the name of a property of type Amazon.SsmSap.Model.GetDatabaseResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.SsmSap.Model.GetDatabaseResponse, GetSMSAPDatabaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            context.ComponentId = this.ComponentId;
            context.DatabaseArn = this.DatabaseArn;
            context.DatabaseId = this.DatabaseId;
            
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
            var request = new Amazon.SsmSap.Model.GetDatabaseRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.ComponentId != null)
            {
                request.ComponentId = cmdletContext.ComponentId;
            }
            if (cmdletContext.DatabaseArn != null)
            {
                request.DatabaseArn = cmdletContext.DatabaseArn;
            }
            if (cmdletContext.DatabaseId != null)
            {
                request.DatabaseId = cmdletContext.DatabaseId;
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
        
        private Amazon.SsmSap.Model.GetDatabaseResponse CallAWSServiceOperation(IAmazonSsmSap client, Amazon.SsmSap.Model.GetDatabaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager for SAP", "GetDatabase");
            try
            {
                #if DESKTOP
                return client.GetDatabase(request);
                #elif CORECLR
                return client.GetDatabaseAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String ComponentId { get; set; }
            public System.String DatabaseArn { get; set; }
            public System.String DatabaseId { get; set; }
            public System.Func<Amazon.SsmSap.Model.GetDatabaseResponse, GetSMSAPDatabaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
