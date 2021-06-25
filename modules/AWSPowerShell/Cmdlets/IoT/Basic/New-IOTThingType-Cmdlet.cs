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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Creates a new thing type.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">CreateThingType</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("New", "IOTThingType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.CreateThingTypeResponse")]
    [AWSCmdlet("Calls the AWS IoT CreateThingType API operation.", Operation = new[] {"CreateThingType"}, SelectReturnType = typeof(Amazon.IoT.Model.CreateThingTypeResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.CreateThingTypeResponse",
        "This cmdlet returns an Amazon.IoT.Model.CreateThingTypeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTThingTypeCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter ThingTypeProperties_SearchableAttribute
        /// <summary>
        /// <para>
        /// <para>A list of searchable thing attribute names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ThingTypeProperties_SearchableAttributes")]
        public System.String[] ThingTypeProperties_SearchableAttribute { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata which can be used to manage the thing type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoT.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ThingTypeProperties_ThingTypeDescription
        /// <summary>
        /// <para>
        /// <para>The description of the thing type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ThingTypeProperties_ThingTypeDescription { get; set; }
        #endregion
        
        #region Parameter ThingTypeName
        /// <summary>
        /// <para>
        /// <para>The name of the thing type.</para>
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
        public System.String ThingTypeName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.CreateThingTypeResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.CreateThingTypeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ThingTypeName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ThingTypeName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ThingTypeName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ThingTypeName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTThingType (CreateThingType)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.CreateThingTypeResponse, NewIOTThingTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ThingTypeName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoT.Model.Tag>(this.Tag);
            }
            context.ThingTypeName = this.ThingTypeName;
            #if MODULAR
            if (this.ThingTypeName == null && ParameterWasBound(nameof(this.ThingTypeName)))
            {
                WriteWarning("You are passing $null as a value for parameter ThingTypeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ThingTypeProperties_SearchableAttribute != null)
            {
                context.ThingTypeProperties_SearchableAttribute = new List<System.String>(this.ThingTypeProperties_SearchableAttribute);
            }
            context.ThingTypeProperties_ThingTypeDescription = this.ThingTypeProperties_ThingTypeDescription;
            
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
            var request = new Amazon.IoT.Model.CreateThingTypeRequest();
            
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.ThingTypeName != null)
            {
                request.ThingTypeName = cmdletContext.ThingTypeName;
            }
            
             // populate ThingTypeProperties
            var requestThingTypePropertiesIsNull = true;
            request.ThingTypeProperties = new Amazon.IoT.Model.ThingTypeProperties();
            List<System.String> requestThingTypeProperties_thingTypeProperties_SearchableAttribute = null;
            if (cmdletContext.ThingTypeProperties_SearchableAttribute != null)
            {
                requestThingTypeProperties_thingTypeProperties_SearchableAttribute = cmdletContext.ThingTypeProperties_SearchableAttribute;
            }
            if (requestThingTypeProperties_thingTypeProperties_SearchableAttribute != null)
            {
                request.ThingTypeProperties.SearchableAttributes = requestThingTypeProperties_thingTypeProperties_SearchableAttribute;
                requestThingTypePropertiesIsNull = false;
            }
            System.String requestThingTypeProperties_thingTypeProperties_ThingTypeDescription = null;
            if (cmdletContext.ThingTypeProperties_ThingTypeDescription != null)
            {
                requestThingTypeProperties_thingTypeProperties_ThingTypeDescription = cmdletContext.ThingTypeProperties_ThingTypeDescription;
            }
            if (requestThingTypeProperties_thingTypeProperties_ThingTypeDescription != null)
            {
                request.ThingTypeProperties.ThingTypeDescription = requestThingTypeProperties_thingTypeProperties_ThingTypeDescription;
                requestThingTypePropertiesIsNull = false;
            }
             // determine if request.ThingTypeProperties should be set to null
            if (requestThingTypePropertiesIsNull)
            {
                request.ThingTypeProperties = null;
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
        
        private Amazon.IoT.Model.CreateThingTypeResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreateThingTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreateThingType");
            try
            {
                #if DESKTOP
                return client.CreateThingType(request);
                #elif CORECLR
                return client.CreateThingTypeAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.IoT.Model.Tag> Tag { get; set; }
            public System.String ThingTypeName { get; set; }
            public List<System.String> ThingTypeProperties_SearchableAttribute { get; set; }
            public System.String ThingTypeProperties_ThingTypeDescription { get; set; }
            public System.Func<Amazon.IoT.Model.CreateThingTypeResponse, NewIOTThingTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
