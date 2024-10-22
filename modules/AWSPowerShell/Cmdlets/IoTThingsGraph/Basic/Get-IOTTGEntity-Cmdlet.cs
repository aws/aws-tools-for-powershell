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
using Amazon.IoTThingsGraph;
using Amazon.IoTThingsGraph.Model;

namespace Amazon.PowerShell.Cmdlets.IOTTG
{
    /// <summary>
    /// Gets definitions of the specified entities. Uses the latest version of the user's
    /// namespace by default. This API returns the following TDM entities.
    /// 
    ///  <ul><li><para>
    /// Properties
    /// </para></li><li><para>
    /// States
    /// </para></li><li><para>
    /// Events
    /// </para></li><li><para>
    /// Actions
    /// </para></li><li><para>
    /// Capabilities
    /// </para></li><li><para>
    /// Mappings
    /// </para></li><li><para>
    /// Devices
    /// </para></li><li><para>
    /// Device Models
    /// </para></li><li><para>
    /// Services
    /// </para></li></ul><para>
    /// This action doesn't return definitions for systems, flows, and deployments.
    /// </para><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Get", "IOTTGEntity")]
    [OutputType("Amazon.IoTThingsGraph.Model.EntityDescription")]
    [AWSCmdlet("Calls the AWS IoT Things Graph GetEntities API operation.", Operation = new[] {"GetEntities"}, SelectReturnType = typeof(Amazon.IoTThingsGraph.Model.GetEntitiesResponse))]
    [AWSCmdletOutput("Amazon.IoTThingsGraph.Model.EntityDescription or Amazon.IoTThingsGraph.Model.GetEntitiesResponse",
        "This cmdlet returns a collection of Amazon.IoTThingsGraph.Model.EntityDescription objects.",
        "The service call response (type Amazon.IoTThingsGraph.Model.GetEntitiesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    [System.ObsoleteAttribute("since: 2022-08-30")]
    public partial class GetIOTTGEntityCmdlet : AmazonIoTThingsGraphClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>An array of entity IDs.</para><para>The IDs should be in the following format.</para><para><c>urn:tdm:REGION/ACCOUNT ID/default:device:DEVICENAME</c></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Ids")]
        public System.String[] Id { get; set; }
        #endregion
        
        #region Parameter NamespaceVersion
        /// <summary>
        /// <para>
        /// <para>The version of the user's namespace. Defaults to the latest version of the user's
        /// namespace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? NamespaceVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Descriptions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTThingsGraph.Model.GetEntitiesResponse).
        /// Specifying the name of a property of type Amazon.IoTThingsGraph.Model.GetEntitiesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Descriptions";
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
                context.Select = CreateSelectDelegate<Amazon.IoTThingsGraph.Model.GetEntitiesResponse, GetIOTTGEntityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Id != null)
            {
                context.Id = new List<System.String>(this.Id);
            }
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NamespaceVersion = this.NamespaceVersion;
            
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
            var request = new Amazon.IoTThingsGraph.Model.GetEntitiesRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Ids = cmdletContext.Id;
            }
            if (cmdletContext.NamespaceVersion != null)
            {
                request.NamespaceVersion = cmdletContext.NamespaceVersion.Value;
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
        
        private Amazon.IoTThingsGraph.Model.GetEntitiesResponse CallAWSServiceOperation(IAmazonIoTThingsGraph client, Amazon.IoTThingsGraph.Model.GetEntitiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Things Graph", "GetEntities");
            try
            {
                #if DESKTOP
                return client.GetEntities(request);
                #elif CORECLR
                return client.GetEntitiesAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? NamespaceVersion { get; set; }
            public System.Func<Amazon.IoTThingsGraph.Model.GetEntitiesResponse, GetIOTTGEntityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Descriptions;
        }
        
    }
}
