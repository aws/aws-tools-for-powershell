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
using Amazon.Greengrass;
using Amazon.Greengrass.Model;

namespace Amazon.PowerShell.Cmdlets.GG
{
    /// <summary>
    /// Creates a connector definition. You may provide the initial version of the connector
    /// definition now or use ''CreateConnectorDefinitionVersion'' at a later time.
    /// </summary>
    [Cmdlet("New", "GGConnectorDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Greengrass.Model.CreateConnectorDefinitionResponse")]
    [AWSCmdlet("Calls the AWS Greengrass CreateConnectorDefinition API operation.", Operation = new[] {"CreateConnectorDefinition"})]
    [AWSCmdletOutput("Amazon.Greengrass.Model.CreateConnectorDefinitionResponse",
        "This cmdlet returns a Amazon.Greengrass.Model.CreateConnectorDefinitionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGGConnectorDefinitionCmdlet : AmazonGreengrassClientCmdlet, IExecutor
    {
        
        #region Parameter AmznClientToken
        /// <summary>
        /// <para>
        /// A client token used to correlate requests
        /// and responses.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AmznClientToken { get; set; }
        #endregion
        
        #region Parameter InitialVersion_Connector
        /// <summary>
        /// <para>
        /// A list of references to connectors in this
        /// version, with their corresponding configuration settings.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InitialVersion_Connectors")]
        public Amazon.Greengrass.Model.Connector[] InitialVersion_Connector { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The name of the connector definition.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// Tag(s) to add to the new resource
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GGConnectorDefinition (CreateConnectorDefinition)"))
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
            
            context.AmznClientToken = this.AmznClientToken;
            if (this.InitialVersion_Connector != null)
            {
                context.InitialVersion_Connectors = new List<Amazon.Greengrass.Model.Connector>(this.InitialVersion_Connector);
            }
            context.Name = this.Name;
            if (this.Tag != null)
            {
                context.Tags = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tags.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.Greengrass.Model.CreateConnectorDefinitionRequest();
            
            if (cmdletContext.AmznClientToken != null)
            {
                request.AmznClientToken = cmdletContext.AmznClientToken;
            }
            
             // populate InitialVersion
            bool requestInitialVersionIsNull = true;
            request.InitialVersion = new Amazon.Greengrass.Model.ConnectorDefinitionVersion();
            List<Amazon.Greengrass.Model.Connector> requestInitialVersion_initialVersion_Connector = null;
            if (cmdletContext.InitialVersion_Connectors != null)
            {
                requestInitialVersion_initialVersion_Connector = cmdletContext.InitialVersion_Connectors;
            }
            if (requestInitialVersion_initialVersion_Connector != null)
            {
                request.InitialVersion.Connectors = requestInitialVersion_initialVersion_Connector;
                requestInitialVersionIsNull = false;
            }
             // determine if request.InitialVersion should be set to null
            if (requestInitialVersionIsNull)
            {
                request.InitialVersion = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.Greengrass.Model.CreateConnectorDefinitionResponse CallAWSServiceOperation(IAmazonGreengrass client, Amazon.Greengrass.Model.CreateConnectorDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Greengrass", "CreateConnectorDefinition");
            try
            {
                #if DESKTOP
                return client.CreateConnectorDefinition(request);
                #elif CORECLR
                return client.CreateConnectorDefinitionAsync(request).GetAwaiter().GetResult();
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
            public System.String AmznClientToken { get; set; }
            public List<Amazon.Greengrass.Model.Connector> InitialVersion_Connectors { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tags { get; set; }
        }
        
    }
}
