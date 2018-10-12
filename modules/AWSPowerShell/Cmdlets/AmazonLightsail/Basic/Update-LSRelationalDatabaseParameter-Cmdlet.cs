/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Allows the update of one or more parameters of a database in Amazon Lightsail.
    /// 
    ///  
    /// <para>
    /// Parameter updates don't cause outages; therefore, their application is not subject
    /// to the preferred maintenance window. However, there are two ways in which paramater
    /// updates are applied: <code>dynamic</code> or <code>pending-reboot</code>. Parameters
    /// marked with a <code>dynamic</code> apply type are applied immediately. Parameters
    /// marked with a <code>pending-reboot</code> apply type are applied only after the database
    /// is rebooted using the <code>reboot relational database</code> operation.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "LSRelationalDatabaseParameter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail UpdateRelationalDatabaseParameters API operation.", Operation = new[] {"UpdateRelationalDatabaseParameters"})]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation",
        "This cmdlet returns a collection of Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.UpdateRelationalDatabaseParametersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLSRelationalDatabaseParameterCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The database parameters to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Parameters")]
        public Amazon.Lightsail.Model.RelationalDatabaseParameter[] Parameter { get; set; }
        #endregion
        
        #region Parameter RelationalDatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of your database for which to update parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RelationalDatabaseName { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RelationalDatabaseName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LSRelationalDatabaseParameter (UpdateRelationalDatabaseParameters)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.Parameter != null)
            {
                context.Parameters = new List<Amazon.Lightsail.Model.RelationalDatabaseParameter>(this.Parameter);
            }
            context.RelationalDatabaseName = this.RelationalDatabaseName;
            
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
            var request = new Amazon.Lightsail.Model.UpdateRelationalDatabaseParametersRequest();
            
            if (cmdletContext.Parameters != null)
            {
                request.Parameters = cmdletContext.Parameters;
            }
            if (cmdletContext.RelationalDatabaseName != null)
            {
                request.RelationalDatabaseName = cmdletContext.RelationalDatabaseName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Operations;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.Lightsail.Model.UpdateRelationalDatabaseParametersResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.UpdateRelationalDatabaseParametersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "UpdateRelationalDatabaseParameters");
            try
            {
                #if DESKTOP
                return client.UpdateRelationalDatabaseParameters(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateRelationalDatabaseParametersAsync(request);
                return task.Result;
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
            public List<Amazon.Lightsail.Model.RelationalDatabaseParameter> Parameters { get; set; }
            public System.String RelationalDatabaseName { get; set; }
        }
        
    }
}
